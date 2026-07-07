using ERPComercial.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços da API
builder.Services.AddControllers();

// Configuração do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de Dependência do Entity Framework Core
var stringDeConexao = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<ErpContexto>(opcoes =>
    opcoes.UseSqlServer(stringDeConexao));

var app = builder.Build();

// Configura o pipeline de requisições HTTP (Middlewares)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();