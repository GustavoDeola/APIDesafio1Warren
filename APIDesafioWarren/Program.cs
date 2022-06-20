using APIDesafioWarren.DomainService;
using APIDesafioWarren.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using AppServices;
using System.Reflection;
using AutoMapper;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

var assemblie = new[] { Assembly.Load("App.Services") };
builder.Services
    .AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssembly(assemblie.First());
    });

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ICustomerServices, CustomerServices>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddAutoMapper((_, mapperConfiguration) => mapperConfiguration.AddMaps(assemblie), assemblie);

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
