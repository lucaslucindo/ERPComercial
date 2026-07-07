using Microsoft.EntityFrameworkCore;

namespace ERPComercial.Infraestrutura.Contexto;

public class ErpContexto : DbContext
{
    public ErpContexto(DbContextOptions<ErpContexto> opcoes) : base(opcoes)
    {
    }
}