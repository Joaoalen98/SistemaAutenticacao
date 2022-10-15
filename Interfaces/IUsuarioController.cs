using SistemaAutenticacao.Models;

namespace SistemaAutenticacao.Interfaces
{
    public interface IUsuarioController
    {
        Usuario? GetUsuario(LoginViewModel dados);
    }
}