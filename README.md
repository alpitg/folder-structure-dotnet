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
```
