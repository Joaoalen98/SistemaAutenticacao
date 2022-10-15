using SistemaAutenticacao.Models;

namespace SistemaAutenticacao.Data
{
    public class UsuarioData
    {

        private Usuario[] _usuarios = new Usuario[]
        {
            new Usuario { Id = 1, Username = "gerente", Senha = "senhaGerente", Cargo = "Gerente" },
            new Usuario { Id = 2, Username = "auxiliar", Senha = "senhaAuxiliar", Cargo = "Auxiliar" }
        };

        public Usuario Get(string userName, string password)
        {
            return _usuarios.Where(u =>
                u.Username == userName && u.Senha == password).FirstOrDefault();
        }
    }
}
