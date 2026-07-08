using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPComercial.Aplicacao.Contratos;
using ERPComercial.Aplicacao.DTOs;
using ERPComercial.Dominio.Contratos;
using ERPComercial.Dominio.Entidades;

namespace ERPComercial.Aplicacao.Servicos;

public class ServicoDeProduto : IServicoDeProduto
{
    private readonly IRepositorioDeProduto _repositorio;

    public ServicoDeProduto(IRepositorioDeProduto repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task AdicionarProdutoAsync(ProdutoDTO produtoDto)
    {
        // Converte o DTO que veio da tela para a Entidade que o banco entende
        // Aqui, forçamos um PrecoDeCusto inicial zerado, já que o DTO não o traz.
        var produto = new Produto(
            produtoDto.Nome,
            produtoDto.Descricao,
            0m, // Preço de Custo
            produtoDto.PrecoDeVenda,
            produtoDto.QuantidadeEmEstoque);

        await _repositorio.AdicionarAsync(produto);
    }

    public async Task<IEnumerable<ProdutoDTO>> ObterTodosAsync()
    {
        var produtos = await _repositorio.ObterTodosAsync();

        // Converte a Entidade do banco de volta para DTO para mostrar na tela
        return produtos.Select(p => new ProdutoDTO
        {
            CodigoProduto = p.CodigoProduto,
            Nome = p.Nome,
            Descricao = p.Descricao,
            PrecoDeVenda = p.PrecoDeVenda,
            QuantidadeEmEstoque = p.QuantidadeEmEstoque
        });
    }

    public async Task AdicionarEstoqueAsync(int codigoProduto, int quantidade)
    {
        if (quantidade <= 0)
            throw new Exception("A quantidade para adicionar deve ser maior que zero.");

        var produto = await _repositorio.ObterPorCodigoAsync(codigoProduto);
        if (produto == null)
            throw new Exception("Produto não encontrado.");

        produto.QuantidadeEmEstoque += quantidade;
        await _repositorio.AtualizarAsync(produto);
    }
}