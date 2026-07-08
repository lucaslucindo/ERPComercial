using ERPComercial.Dominio.Enums;
using System;

namespace ERPComercial.Dominio.Entidades
{
    public class ContaAReceber
    {
        public int CodigoContaReceber { get; set; }
        public int CodigoCliente { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public DateTime? DataDeRecebimento { get; set; } // A interrogação (?) significa que pode ser nulo (ainda não foi paga)
        public StatusDaConta Status { get; set; } = StatusDaConta.Pendente;

        public Cliente Cliente { get; set; } = null!; // Propriedade de navegação para a entidade Cliente

        public void RegistrarRecebimento()
        {
            if (Status == StatusDaConta.Paga)
                throw new Exception("Essa conta já foi recebida.");

            Status = StatusDaConta.Paga;
            DataDeRecebimento = DateTime.Now;
        }
    }
}
