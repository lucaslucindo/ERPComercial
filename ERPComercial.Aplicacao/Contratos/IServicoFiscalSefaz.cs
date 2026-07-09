using System.Threading.Tasks;
using ERPComercial.Dominio.Entidades;

namespace ERPComercial.Aplicacao.Contratos;

public interface IServicoFiscalSefaz
{
    // Recebe uma Venda e retorna uma NotaFiscal preenchida com os dados da SEFAZ
    Task<NotaFiscal> EmitirNotaFiscalAsync(Venda venda);
}