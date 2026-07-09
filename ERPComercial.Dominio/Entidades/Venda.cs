using System;
using System.Collections.Generic;

namespace ERPComercial.Dominio.Entidades;

public class Venda
{
    public int CodigoVenda { get; set; }
    public int CodigoCliente { get; set; }
    public DateTime DataDaVenda { get; set; }
    public decimal ValorTotal { get; private set; }

    // Relacionamento de Navegação
    public Cliente Cliente { get; set; } = null!;
    public List<ItemVenda> Itens { get; set; } = new List<ItemVenda>();

    public void CalcularTotal()
    {
        ValorTotal = 0;
        foreach (var item in Itens)
        {
            ValorTotal += item.ValorSubtotal;
        }
    }
}