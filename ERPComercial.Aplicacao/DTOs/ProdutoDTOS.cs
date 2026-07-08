namespace ERPComercial.Aplicacao.DTOs;

public class ProdutoDTO
{   
    public int CodigoProduto { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal PrecoDeVenda { get; set; }
    public int QuantidadeEmEstoque { get; set; }
}