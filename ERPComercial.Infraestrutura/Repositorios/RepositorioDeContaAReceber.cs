using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPComercial.Dominio.Contratos;
using ERPComercial.Dominio.Entidades;
using ERPComercial.Dominio.Enums;
using ERPComercial.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ERPComercial.Infraestrutura.Repositorios;

public class RepositorioDeContaAReceber : IRepositorioDeContaAReceber
{
    private readonly ErpContexto _contexto;

    public RepositorioDeContaAReceber(ErpContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task AdicionarAsync(ContaAReceber conta)
    {
        await _contexto.ContasAReceber.AddAsync(conta);
        await _contexto.SaveChangesAsync();
    }

    public async Task<ContaAReceber?> ObterPorCodigoAsync(int codigoConta)
    {
        return await _contexto.ContasAReceber.FirstOrDefaultAsync(c => c.CodigoContaReceber == codigoConta);
    }

    public async Task AtualizarAsync(ContaAReceber conta)
    {
        _contexto.ContasAReceber.Update(conta);
        await _contexto.SaveChangesAsync();
    }

    public async Task<IEnumerable<ContaAReceber>> ObterPendentesAsync()
    {
        return await _contexto.ContasAReceber
            .Where(c => c.Status == StatusDaConta.Pendente)
            .AsNoTracking()
            .ToListAsync();
    }
}