using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPComercial.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_clientes",
                columns: table => new
                {
                    CodigoCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_clientes", x => x.CodigoCliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_fornecedores",
                columns: table => new
                {
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_fornecedores", x => x.CodigoFornecedor);
                });

            migrationBuilder.CreateTable(
                name: "tb_produtos",
                columns: table => new
                {
                    CodigoProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoDeCusto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecoDeVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeEmEstoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produtos", x => x.CodigoProduto);
                });

            migrationBuilder.CreateTable(
                name: "tb_vendas",
                columns: table => new
                {
                    CodigoVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    DataDaVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteCodigoCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_vendas", x => x.CodigoVenda);
                    table.ForeignKey(
                        name: "FK_tb_vendas_tb_clientes_ClienteCodigoCliente",
                        column: x => x.ClienteCodigoCliente,
                        principalTable: "tb_clientes",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_itens_venda",
                columns: table => new
                {
                    CodigoItemVenda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoVenda = table.Column<int>(type: "int", nullable: false),
                    CodigoProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VendaCodigoVenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_itens_venda", x => x.CodigoItemVenda);
                    table.ForeignKey(
                        name: "FK_tb_itens_venda_tb_produtos_CodigoProduto",
                        column: x => x.CodigoProduto,
                        principalTable: "tb_produtos",
                        principalColumn: "CodigoProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_itens_venda_tb_vendas_VendaCodigoVenda",
                        column: x => x.VendaCodigoVenda,
                        principalTable: "tb_vendas",
                        principalColumn: "CodigoVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_itens_venda_CodigoProduto",
                table: "tb_itens_venda",
                column: "CodigoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_itens_venda_VendaCodigoVenda",
                table: "tb_itens_venda",
                column: "VendaCodigoVenda");

            migrationBuilder.CreateIndex(
                name: "IX_tb_vendas_ClienteCodigoCliente",
                table: "tb_vendas",
                column: "ClienteCodigoCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_fornecedores");

            migrationBuilder.DropTable(
                name: "tb_itens_venda");

            migrationBuilder.DropTable(
                name: "tb_produtos");

            migrationBuilder.DropTable(
                name: "tb_vendas");

            migrationBuilder.DropTable(
                name: "tb_clientes");
        }
    }
}
