using MediatR;
using FluentValidation;
using Structure.Infrastructure.Extensions;
using Structure.MediatR.PipeLineBehavior;
using Structure.Data.Dto;
using Structure.Helper;
using Structure.Api.Helpers.Mapping;
using Microsoft.AspNetCore.Identity;
using Structure.Data;
using Structure.Domain;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json", optional: false)
       .Build();


// Add services to the container.

var assembly = AppDomain.CurrentDomain.Load("Structure.MediatR");
var defaultUserId = configuration.GetSection("DefaultUser").GetSection("DefaultUserId").Value;
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssemblies(Enumerable.Repeat(assembly, 1));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton(new PathHelper(configuration));
builder.Services.AddScoped(c => new UserInfoToken() { Id = defaultUserId });
builder.Services.AddDbContextExt(configuration);
builder.Services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<StructureDbContext>()
            .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
});
builder.Services.AddSingleton(MapperConfig.GetMapperConfigs());
builder.Services.AddDependencyInjection();
builder.Services.AddJwtExt(configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000",
                                "http://localhost:4000",
                                "http://localhost:4200",
                                 "http://localhost:4201"
                             )
                   .WithExposedHeaders("X-Pagination")
                   .AllowAnyHeader()
                   .AllowCredentials()
                   .WithMethods("POST", "PUT", "PATCH", "GET", "DELETE")
                   .SetIsOriginAllowed(host => true);
        });
});
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AutomaticAuthentication = false;
});
builder.Services.AddControllers();
builder.Services.AddSwaggerExt();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerExt();
}


app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();


