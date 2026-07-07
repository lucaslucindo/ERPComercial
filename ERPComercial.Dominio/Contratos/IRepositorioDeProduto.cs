using System.Collections.Generic;
using System.Threading.Tasks;
using ERPComercial.Dominio.Entidades;

namespace ERPComercial.Dominio.Contratos;

public interface IRepositorioDeProduto
{
    Task AdicionarAsync(Produto produto);
    Task<Produto?> ObterPorCodigoAsync(int codigoProduto); // Regra de Ouro
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task AtualizarAsync(Produto produto);
}