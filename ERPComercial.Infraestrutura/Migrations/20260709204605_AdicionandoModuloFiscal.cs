using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPComercial.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoModuloFiscal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_notas_fiscais",
                columns: table => new
                {
                    CodigoNotaFiscal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoVenda = table.Column<int>(type: "int", nullable: false),
                    ChaveDeAcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtocoloAutorizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XmlGerado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeEmissao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_notas_fiscais", x => x.CodigoNotaFiscal);
                    table.ForeignKey(
                        name: "FK_tb_notas_fiscais_tb_vendas_CodigoVenda",
                        column: x => x.CodigoVenda,
                        principalTable: "tb_vendas",
                        principalColumn: "CodigoVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_notas_fiscais_CodigoVenda",
                table: "tb_notas_fiscais",
                column: "CodigoVenda",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_notas_fiscais");
        }
    }
}
