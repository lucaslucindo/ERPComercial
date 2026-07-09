namespace ERPComercial.Dominio.Entidades
{
    public class ItemVenda
    {
        public int CodigoItemVenda { get; set; }
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }

        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorSubtotal => Quantidade * ValorUnitario;

        // Relacionamento com Produto
        public Venda Venda { get; set; } = null!;
        public Produto Produto { get; set; } = null!;
    }
}
