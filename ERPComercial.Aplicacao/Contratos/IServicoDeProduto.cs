using System.Collections.Generic;
using System.Threading.Tasks;
using ERPComercial.Aplicacao.DTOs;

namespace ERPComercial.Aplicacao.Contratos;

public interface IServicoDeProduto
{
    Task AdicionarProdutoAsync(ProdutoDTO produtoDto);
    Task<IEnumerable<ProdutoDTO>> ObterTodosAsync();
    Task AdicionarEstoqueAsync(int codigoProduto, int quantidade);
}