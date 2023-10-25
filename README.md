# folder-structure-dotnet

ASP.NET 6.0 | folder structure

### Fresh project create commands

```
dotnet new sln -n Structure
dotnet new webapi -n Structure.Api
dotnet new classlib -n Structure.Data
dotnet new classlib -n Structure.Domain
dotnet new classlib -n Structure.Helper
dotnet new classlib -n Structure.Infrastructure
dotnet new classlib -n Structure.MediatR
dotnet new classlib -n Structure.Repository

dotnet sln add src/Structure.Api/Structure.Api.csproj
dotnet sln add src/Structure.Data/Structure.Data.csproj
dotnet sln add src/Structure.Domain/Structure.Domain.csproj
dotnet sln add src/Structure.Helper/Structure.Helper.csproj
dotnet sln add src/Structure.Infrastructure/Structure.Infrastructure.csproj
dotnet sln add src/Structure.MediatR/Structure.MediatR.csproj
dotnet sln add src/Structure.Repository/Structure.Repository.csproj

dotnet build
dotnet
```

### Migration - Update-Database

```c#
Update-Database -Connection "YOUR_CONNECTION_STRING"
```


### Migration - Mac commands
- NOTE: Check SQL section to clean db before applying clean migration

```c#
dotnet tool install --global dotnet-ef

dotnet ef --startup-project ../Structure.Api  migrations add initial 
dotnet ef --startup-project ../Structure.Api database update --connection "Server=localhost; Database=sharedTenantDb; User Id=SA; Password=Password123; Trusted_Connection=false;Encrypt=false;"
```


### Migration class file to insert initial data

```c#
// NOTE: When u create the .sql file, do this following changes for the file
// Build Action - Embedded resource
// Copy to output directory - Copy always

using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using System.Text.RegularExpressions;

#nullable disable

namespace Structure.Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = GetType();
            var regex = new Regex($@"{Regex.Escape(type.Namespace)}\.\d{{14}}_{Regex.Escape(type.Name)}\.sql");

            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(x => regex.IsMatch(x));
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            var sqlResult = reader.ReadToEnd();
            migrationBuilder.Sql(sqlResult);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
```

```sql
INSERT [dbo].[Users] ([Id], [FirstName]) VALUES (N'1a5cf5b9-ead8-495c-8719-2d8be776f452', N'Amit');
GO

-- DROP database
alter database [sharedTenantDb] set single_user with rollback immediate
drop database [sharedTenantDb]
```


### reference for Email confirmation
```c#
public async Task<IActionResult> Register(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Invalid user name or password.");
            }

            var user = new ApplicationUser { UserName = userName, Email = userName };

            var tenant = context.Tenants.ToList().Where(t => t.Hosts.Split(',').Where(h => h.Contains(this.HttpContext.Request.Host.Value)).Any()).FirstOrDefault();
            if (tenant != null)
            {
                userManager.UserValidators.Clear();

                if (context.Users.Any(u => u.TenantId == tenant.Id && u.UserName == user.Name))
                {
                    return BadRequest("User with the same name already exist for this tenant.");
                }
            }

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                try
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code }, protocol: Request.Scheme);

                    var body = string.Format(@"<a href=""{0}"">{1}</a>", callbackUrl, "Please confirm your registration");

                    await SendEmailAsync(user.Email, "Confirm your registration", body);


                    var newUser = context.Users.FirstOrDefault(u => u.TenantId == tenant.Id && u.UserName == userName);
                    if (newUser != null && tenant != null)
                    {
                        newUser.TenantId = tenant.Id;
                        context.Users.Update(newUser);
                        context.SaveChanges();
                    }

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return BadRequest(message);
        }
```