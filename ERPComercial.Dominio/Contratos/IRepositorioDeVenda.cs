using System.Threading.Tasks;
using ERPComercial.Dominio.Entidades;

namespace ERPComercial.Dominio.Contratos;

public interface IRepositorioDeVenda
{
    Task RegistrarVendaAsync(Venda venda);
}