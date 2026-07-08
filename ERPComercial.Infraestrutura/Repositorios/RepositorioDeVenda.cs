using System.Threading.Tasks;
using ERPComercial.Dominio.Contratos;
using ERPComercial.Dominio.Entidades;
using ERPComercial.Infraestrutura.Contexto;

namespace ERPComercial.Infraestrutura.Repositorios;

public class RepositorioDeVenda : IRepositorioDeVenda
{
    private readonly ErpContexto _contexto;

    public RepositorioDeVenda(ErpContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task RegistrarVendaAsync(Venda venda)
    {
        await _contexto.Vendas.AddAsync(venda);
        await _contexto.SaveChangesAsync();
    }
}