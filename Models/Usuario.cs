namespace SistemaAutenticacao.Models
{
    public class Usuario
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string? Cargo { get; set; }
    }
}
