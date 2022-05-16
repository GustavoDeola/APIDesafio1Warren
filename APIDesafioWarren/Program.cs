using APIDesafioWarren.DataBase;
using APIDesafioWarren.Validations;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.
AddControllers()
.AddFluentValidation
( cfg => cfg.RegisterValidatorsFromAssemblyContaining<CustomerValidator>());

builder.Services.
    AddSwaggerGen();
builder.Services.
    AddEndpointsApiExplorer();
builder.Services
    .AddMemoryCache();
builder.Services
    .AddSingleton<ICustomerServices, CustomerServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
