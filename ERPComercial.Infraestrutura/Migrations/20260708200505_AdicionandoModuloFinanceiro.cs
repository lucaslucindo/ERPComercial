using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPComercial.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoModuloFinanceiro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_contas_a_receber",
                columns: table => new
                {
                    CodigoContaReceber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoCliente = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataDeVencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ClienteCodigoCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_contas_a_receber", x => x.CodigoContaReceber);
                    table.ForeignKey(
                        name: "FK_tb_contas_a_receber_tb_clientes_ClienteCodigoCliente",
                        column: x => x.ClienteCodigoCliente,
                        principalTable: "tb_clientes",
                        principalColumn: "CodigoCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_contas_a_receber_ClienteCodigoCliente",
                table: "tb_contas_a_receber",
                column: "ClienteCodigoCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_contas_a_receber");
        }
    }
}
