using System;

namespace ERPComercial.Dominio.Entidades;

public class NotaFiscal
{
    public int CodigoNotaFiscal { get; set; }
    public int CodigoVenda { get; set; } // Ligação com a venda que originou a nota
    public string ChaveDeAcesso { get; set; } = string.Empty;
    public string ProtocoloAutorizacao { get; set; } = string.Empty;
    public string XmlGerado { get; set; } = string.Empty;
    public DateTime DataDeEmissao { get; set; }

    // Relacionamento de Navegação
    public Venda Venda { get; set; } = null!;
}