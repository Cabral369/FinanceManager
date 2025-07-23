
using financeManager.Infrastructure.Extensions;
using financeManager.Application.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(); //configuração da camada de aplicação
builder.Services.AddInfrastructureServices(builder.Configuration); //configuração da camada de infraestrutura
builder.Services.AddInfrastructureRepositories(); //configuracao da camada de infrastructure

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Finance Manager API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Nicolas Cabral Carvalho",
            Email = "seu@email.com"
        }
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();
app.MapControllers();

app.Run();