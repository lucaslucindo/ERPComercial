using System;
using System.Threading.Tasks;
using ERPComercial.Aplicacao.Contratos;
using ERPComercial.Aplicacao.DTOs;
using ERPComercial.Dominio.Contratos;
using ERPComercial.Dominio.Entidades;

namespace ERPComercial.Aplicacao.Servicos;

public class ServicoDeVenda : IServicoDeVenda
{
    private readonly IRepositorioDeVenda _repositorioVenda;
    private readonly IRepositorioDeProduto _repositorioProduto;

    public ServicoDeVenda(IRepositorioDeVenda repositorioVenda, IRepositorioDeProduto repositorioProduto)
    {
        _repositorioVenda = repositorioVenda;
        _repositorioProduto = repositorioProduto;
    }

    public async Task RealizarVendaAsync(NovaVendaDTO vendaDto)
    {
        var venda = new Venda
        {
            CodigoCliente = vendaDto.CodigoCliente,
            DataDaVenda = DateTime.Now
        };

        foreach (var itemDto in vendaDto.Itens)
        {
            // Validações de Produto e Estoque
            var produto = await _repositorioProduto.ObterPorCodigoAsync(itemDto.CodigoProduto);

            if (produto == null)
                throw new Exception($"Produto com código {itemDto.CodigoProduto} não encontrado.");

            if (produto.QuantidadeEmEstoque < itemDto.Quantidade)
                throw new Exception($"Estoque insuficiente para o produto {produto.Nome}. Temos apenas {produto.QuantidadeEmEstoque} unidades.");

            // Regra de Negócio: Baixa automática no estoque
            produto.QuantidadeEmEstoque -= itemDto.Quantidade;
            await _repositorioProduto.AtualizarAsync(produto);

            // Adiciona o item validado na Venda
            venda.Itens.Add(new ItemVenda
            {
                CodigoProduto = produto.CodigoProduto,
                Quantidade = itemDto.Quantidade,
                ValorUnitario = produto.PrecoDeVenda // Pega o preço de venda atualizado do banco
            });
        }

        // Delega o cálculo do valor total para a Entidade
        venda.CalcularTotal();

        await _repositorioVenda.RegistrarVendaAsync(venda);
    }
}