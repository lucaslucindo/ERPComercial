namespace ERPComercial.Dominio.Entidades
{
    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal PrecoDeCusto { get; set; }
        public decimal PrecoDeVenda { get; set; }
        public int QuantidadeEmEstoque { get; set; }

        public Produto() { }

        public Produto(string nome, string descricao, decimal precoDeCusto, decimal precoDeVenda, int quantidadeEmEstoque)
        {
            Nome = nome;
            Descricao = descricao;
            PrecoDeCusto = precoDeCusto;
            PrecoDeVenda = precoDeVenda;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }
    }
}
