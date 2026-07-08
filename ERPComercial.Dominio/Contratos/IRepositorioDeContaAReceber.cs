using System.Collections.Generic;
using System.Threading.Tasks;
using ERPComercial.Dominio.Entidades;

namespace ERPComercial.Dominio.Contratos
{
    public interface IRepositorioDeContaAReceber
    {
        Task AdicionarAsync(ContaAReceber conta);
        Task<ContaAReceber?> ObterPorCodigoAsync(int codigoConta);
        Task AtualizarAsync(ContaAReceber conta);
        Task<IEnumerable<ContaAReceber>> ObterPendentesAsync();
    }
}
