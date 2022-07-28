using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Application;
using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using EntityFrameworkCore.UnitOfWork.Extensions;

var builder = WebApplication.CreateBuilder(args);   

var assembly = Assembly.Load("Application");
builder.Services
    .AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssembly(assembly);
    });

builder.Services.AddDbContext<Context>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("Default"),
                        ServerVersion.Parse("8.0.29-mysql"),
                        b => b.MigrationsAssembly("Infrastructure.Data")));

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ICustomerServices, CustomerServices>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddTransient<DbContext, Context>();
builder.Services.AddUnitOfWork<Context>();
builder.Services.AddAutoMapper((_, mapperConfiguration) => mapperConfiguration.AddMaps(assembly), assembly);

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