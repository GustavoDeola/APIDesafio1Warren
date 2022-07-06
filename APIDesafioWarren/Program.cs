using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Linq;
using Application;
using Domain.Services.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var assemblies = new[] { Assembly.Load("Application") };
builder.Services
    .AddDbContext<APIDesafioWarrenDbContext>(options =>
    {
        options.UseMySql(builder.Configuration.GetConnectionString("Default"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"),
        b => b.MigrationsAssembly("Infrastructure"));
    })
    .AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssembly(assemblies.First());
    });

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ICustomerServices, CustomerServices>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddAutoMapper((_, mapperConfiguration) => mapperConfiguration.AddMaps(assemblies), assemblies);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var supportedCultures = "en-US";
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures)
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);
app.MapControllers();
app.Run();
