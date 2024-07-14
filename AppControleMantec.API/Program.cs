using AppControleMantec.API.Infra.IoC;
using AppControleMantec.Application.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços da aplicação

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

// Registro de serviços do projeto
builder.Services.AddInfrastructureAPI(builder.Configuration);

// Configuração dos serviços da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Title", Version = "v1" });
});

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Configuração do logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
// Adicione outros provedores de log conforme necessário

var app = builder.Build();

// Configuração do pipeline HTTP e HTTPS
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Title v1");
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

// Adicione esta linha para garantir que o Kestrel use as configurações do arquivo appsettings.json
app.Run("http://0.0.0.0:5000");