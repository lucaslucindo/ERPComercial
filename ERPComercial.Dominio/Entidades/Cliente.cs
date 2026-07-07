namespace ERPComercial.Dominio.Entidades
{
    public class Cliente
    {
        public int CodigoCliente { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty; // Pode ser CPF ou CNPJ
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}
