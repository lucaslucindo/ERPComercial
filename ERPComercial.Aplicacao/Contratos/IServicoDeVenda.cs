using System.Threading.Tasks;
using ERPComercial.Aplicacao.DTOs;

namespace ERPComercial.Aplicacao.Contratos;

public interface IServicoDeVenda
{
    Task RealizarVendaAsync(NovaVendaDTO vendaDto);
}