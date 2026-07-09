namespace ERPComercial.Dominio.Entidades
{
    public class Fornecedor
    {
        public int CodigoFornecedor { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string Cnpj { get; set; } = string.Empty;
        public string Contato { get; set; } = string.Empty;
    }
}
