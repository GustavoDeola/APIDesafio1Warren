using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Linq;
using Application;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

var assemblies = new[] { Assembly.Load("Application") };
builder.Services
    .AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssembly(assemblies.First());
    });

builder.Services.AddDbContext<Context>(options => 
        options.UseMySql(builder.Configuration.GetConnectionString("dbAPIWarren"), 
        ServerVersion.Parse("8.0.29-mysql"),
        b => b.MigrationsAssembly("Infrastructure.Data")));

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