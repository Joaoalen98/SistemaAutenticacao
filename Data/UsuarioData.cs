using SistemaAutenticacao.Interfaces;
using SistemaAutenticacao.Models;

namespace SistemaAutenticacao.Data
{
    public class UsuarioData : IUsuarioController
    {

        private Usuario[] _usuarios = new Usuario[]
        {
            new Usuario { Id = 1, Username = "gerente", Senha = "senhaGerente", Cargo = "Gerente" },
            new Usuario { Id = 2, Username = "auxiliar", Senha = "senhaAuxiliar", Cargo = "Auxiliar" }
        };

        public Usuario? GetUsuario(LoginViewModel dados)
        {
            return _usuarios.Where(u =>
                u.Username == dados.UserName && u.Senha == u.Senha).FirstOrDefault();
        }
    }
}
