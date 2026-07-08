using ERPComercial.Aplicacao.Contratos;
using ERPComercial.Aplicacao.Servicos;
using ERPComercial.Dominio.Contratos;
using ERPComercial.Infraestrutura.Contexto;
using ERPComercial.Infraestrutura.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços da API
builder.Services.AddControllers();

builder.Services.AddScoped<IRepositorioDeProduto, RepositorioDeProduto>();
builder.Services.AddScoped<IServicoDeProduto, ServicoDeProduto>();

builder.Services.AddScoped<IRepositorioDeVenda, RepositorioDeVenda>();
builder.Services.AddScoped<IServicoDeVenda, ServicoDeVenda>();

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