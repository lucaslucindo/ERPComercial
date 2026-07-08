using System;
using System.Threading.Tasks;
using ERPComercial.Dominio.Contratos;
using ERPComercial.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ERPComercial.Apresentacao.Controladores;

[ApiController]
[Route("api/financeiro")]
public class ControladorFinanceiro : ControllerBase
{
    private readonly IRepositorioDeContaAReceber _repositorio;

    public ControladorFinanceiro(IRepositorioDeContaAReceber repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpPost("contas-a-receber")]
    public async Task<IActionResult> AdicionarConta([FromBody] ContaAReceber conta)
    {
        await _repositorio.AdicionarAsync(conta);
        return Ok("Conta a receber registrada com sucesso.");
    }

    [HttpGet("contas-a-receber/pendentes")]
    public async Task<IActionResult> ObterPendentes()
    {
        var pendentes = await _repositorio.ObterPendentesAsync();
        return Ok(pendentes);
    }

    [HttpPut("contas-a-receber/{codigoConta}/baixar")]
    public async Task<IActionResult> BaixarConta(int codigoConta)
    {
        try
        {
            var conta = await _repositorio.ObterPorCodigoAsync(codigoConta);
            if (conta == null) return NotFound("Conta não encontrada.");

            conta.RegistrarRecebimento(); // Chamada da regra de negócio do Domínio
            await _repositorio.AtualizarAsync(conta);

            return Ok("Conta baixada (recebida) com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}