using Microsoft.Extensions.DependencyInjection;
using Structure.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
       .AddJsonFile("appsettings.json", optional: false)
       .Build();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContextExt(configuration);
builder.Services.AddSwaggerExt();
//builder.Services.AddScopedServices();
//builder.Services.AddServiceLayer();
//builder.Services.AddVersion();
//builder.Services.AddSwagger();
//builder.Services.AddMemoryCache();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddMailSetting(Configuration);
//builder.Services.AddOtherServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerExt();
}

app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();


