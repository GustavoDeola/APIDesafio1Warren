using APIDesafioWarren.DataBase;
using APIDesafioWarren.Validations;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.
AddControllers()
.AddFluentValidation
( cfg => cfg.RegisterValidatorsFromAssemblyContaining<ClientValidator>());

builder.Services.
    AddSwaggerGen();
builder.Services.
    AddEndpointsApiExplorer();


builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IDataBase, DataBase>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();

//app.UseAuthorization();

app
    .MapControllers();

app.Run();
