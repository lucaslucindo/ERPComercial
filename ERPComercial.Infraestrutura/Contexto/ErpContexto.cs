using ERPComercial.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ERPComercial.Infraestrutura.Contexto;

public class ErpContexto : DbContext
{
    public ErpContexto(DbContextOptions<ErpContexto> opcoes) : base(opcoes) { }

    // Representação das tabelas no banco de dados
    public DbSet<Produto> Produtos { get; set; } = null!;
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Fornecedor> Fornecedores { get; set; } = null!;
    public DbSet<Venda> Vendas { get; set; } = null!;
    public DbSet<ItemVenda> ItensVenda { get; set; } = null!;
    public DbSet<ContaAReceber> ContasAReceber { get; set; } = null!;

    // Método onde configura as regras do banco (Fluent API)
    protected override void OnModelCreating(ModelBuilder construtorDeModelos)
    {
        base.OnModelCreating(construtorDeModelos);

        // Mapeamento da Tabela de Produtos
        construtorDeModelos.Entity<Produto>(entidade =>
        {
            entidade.ToTable("tb_produtos");
            entidade.HasKey(p => p.CodigoProduto); // Configura como Chave Primária (Primary Key)
            entidade.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            entidade.Property(p => p.PrecoDeCusto).HasColumnType("decimal(18,2)");
            entidade.Property(p => p.PrecoDeVenda).HasColumnType("decimal(18,2)");
        });

        // Mapeamento da Tabela de Clientes
        construtorDeModelos.Entity<Cliente>(entidade =>
        {
            entidade.ToTable("tb_clientes");
            entidade.HasKey(c => c.CodigoCliente);
        });

        // Mapeamento da Tabela de Fornecedores
        construtorDeModelos.Entity<Fornecedor>(entidade =>
        {
            entidade.ToTable("tb_fornecedores");
            entidade.HasKey(f => f.CodigoFornecedor);
        });

        // Mapeamento da Tabela de Vendas
        construtorDeModelos.Entity<Venda>(entidade =>
        {
            entidade.ToTable("tb_vendas");
            entidade.HasKey(v => v.CodigoVenda);
            entidade.Property(v => v.ValorTotal).HasColumnType("decimal(18,2)");
        });

        // Mapeamento da Tabela de Itens da Venda
        construtorDeModelos.Entity<ItemVenda>(entidade =>
        {
            entidade.ToTable("tb_itens_venda");
            entidade.HasKey(i => i.CodigoItemVenda);
            entidade.Property(i => i.ValorUnitario).HasColumnType("decimal(18,2)");

            // Relacionamento: Um Item de Venda tem Um Produto
            entidade.HasOne(i => i.Produto)
                    .WithMany()
                    .HasForeignKey(i => i.CodigoProduto);
        });

        // Mapeamento da Tabela de Contas a Receber
        construtorDeModelos.Entity<ContaAReceber>(entidade =>
        {
            entidade.ToTable("tb_contas_a_receber");
            entidade.HasKey(c => c.CodigoContaReceber);
            entidade.Property(c => c.Valor).HasColumnType("decimal(18,2)");

            // Configura o Enum para ser salvo como número inteiro no banco de dados
            entidade.Property(c => c.Status).HasConversion<int>();
        });

        // Mapeamento da Tabela de Notas Fiscais
        construtorDeModelos.Entity<NotaFiscal>(entidade =>
        {
            entidade.ToTable("tb_notas_fiscais");
            entidade.HasKey(n => n.CodigoNotaFiscal);

            // Relacionamento 1 para 1: Uma venda tem uma nota fiscal
            entidade.HasOne(n => n.Venda)
                    .WithOne()
                    .HasForeignKey<NotaFiscal>(n => n.CodigoVenda);
        });
    }
}