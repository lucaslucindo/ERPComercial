using System.Collections.Generic;
using System.Threading.Tasks;
using ERPComercial.Dominio.Contratos;
using ERPComercial.Dominio.Entidades;
using ERPComercial.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace ERPComercial.Infraestrutura.Repositorios;

public class RepositorioDeProduto : IRepositorioDeProduto
{
    private readonly ErpContexto _contexto;

    public RepositorioDeProduto(ErpContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task AdicionarAsync(Produto produto)
    {
        await _contexto.Produtos.AddAsync(produto);
        await _contexto.SaveChangesAsync();
    }

    public async Task<Produto?> ObterPorCodigoAsync(int codigoProduto)
    {
        return await _contexto.Produtos.FirstOrDefaultAsync(p => p.CodigoProduto == codigoProduto);
    }

    public async Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        return await _contexto.Produtos.AsNoTracking().ToListAsync();
    }

    public async Task AtualizarAsync(Produto produto)
    {
        _contexto.Produtos.Update(produto);
        await _contexto.SaveChangesAsync();
    }
}