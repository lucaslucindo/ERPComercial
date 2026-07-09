using System;
using System.Threading.Tasks;
using ERPComercial.Aplicacao.Contratos;
using ERPComercial.Dominio.Entidades;

namespace ERPComercial.Infraestrutura.ServicosExternos;

public class ServicoFiscalSefaz : IServicoFiscalSefaz
{
    public async Task<NotaFiscal> EmitirNotaFiscalAsync(Venda venda)
    {
        // Aqui entraria a biblioteca de geração de XML (ex: Zeus.Net.NFe)
        // Aqui entraria a assinatura com Certificado Digital
        // Aqui ocorreria o POST HTTP para o Web Service da SEFAZ

        // Como estamos preparando a fundação, vamos simular o retorno de sucesso da SEFAZ:
        await Task.Delay(1500); // Simula o tempo de rede até a SEFAZ

        var notaFiscal = new NotaFiscal
        {
            CodigoVenda = venda.CodigoVenda,
            ChaveDeAcesso = Guid.NewGuid().ToString().Replace("-", "") + "1234567890", // Simulando 44 posições
            ProtocoloAutorizacao = "135" + new Random().Next(100000, 999999).ToString(),
            XmlGerado = "<nfe><simulacao>Autorizado o uso da NF-e</simulacao></nfe>",
            DataDeEmissao = DateTime.Now
        };

        return notaFiscal;
    }
}