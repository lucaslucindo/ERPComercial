using System.Collections.Generic;

namespace ERPComercial.Aplicacao.DTOs;

public class NovaVendaDTO
{
    public int CodigoCliente { get; set; }
    public List<NovoItemVendaDTO> Itens { get; set; } = new List<NovoItemVendaDTO>();
}