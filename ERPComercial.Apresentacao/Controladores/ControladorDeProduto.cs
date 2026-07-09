using System;
using System.Threading.Tasks;
using ERPComercial.Aplicacao.Contratos;
using ERPComercial.Aplicacao.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERPComercial.Apresentacao.Controladores;

[ApiController]
[Route("api/produtos")]
public class ControladorDeProduto : ControllerBase
{
    private readonly IServicoDeProduto _servico;

    public ControladorDeProduto(IServicoDeProduto servico)
    {
        _servico = servico;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDTO produtoDto)
    {
        await _servico.AdicionarProdutoAsync(produtoDto);
        return Ok("Produto cadastrado com sucesso.");
    }

    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var produtos = await _servico.ObterTodosAsync();
        return Ok(produtos);
    }

    [HttpPut("{codigoProduto}/estoque/{quantidade}")]
    public async Task<IActionResult> AdicionarEstoque(int codigoProduto, int quantidade)
    {
        try
        {
            await _servico.AdicionarEstoqueAsync(codigoProduto, quantidade);
            return Ok("Estoque atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}