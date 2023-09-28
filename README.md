# folder-structure-dotnet
ASP.NET 6.0 | folder structure


### Fresh project create commands

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