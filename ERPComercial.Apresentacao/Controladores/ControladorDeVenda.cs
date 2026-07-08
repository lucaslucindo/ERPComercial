using System;
using System.Threading.Tasks;
using ERPComercial.Aplicacao.Contratos;
using ERPComercial.Aplicacao.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ERPComercial.Apresentacao.Controladores;

[ApiController]
[Route("api/vendas")]
public class ControladorDeVenda : ControllerBase
{
    private readonly IServicoDeVenda _servico;

    public ControladorDeVenda(IServicoDeVenda servico)
    {
        _servico = servico;
    }

    [HttpPost]
    public async Task<IActionResult> RealizarVenda([FromBody] NovaVendaDTO vendaDto)
    {
        try
        {
            await _servico.RealizarVendaAsync(vendaDto);
            return Ok("Venda realizada com sucesso e estoque atualizado!");
        }
        catch (Exception ex)
        {
            // Em caso de erro de estoque, retornamos Bad Request (400) com a mensagem
            return BadRequest(ex.Message);
        }
    }
}