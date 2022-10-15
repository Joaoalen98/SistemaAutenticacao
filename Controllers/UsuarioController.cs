using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaAutenticacao.Interfaces;
using SistemaAutenticacao.Models;
using SistemaAutenticacao.Services;

namespace SistemaAutenticacao.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioController _usuarios;

        public UsuarioController(IUsuarioController usuarioController)
        {
            _usuarios = usuarioController;
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel body)
        {
            var usuario = _usuarios.GetUsuario(body);

            if (usuario == null)
            {
                return BadRequest(new { res = "Usuário ou senha incorreta" });
            }
            usuario.Senha = "";

            var token = Token.GerarToken(usuario);

            return Ok(new { usuario, token });
        }


        [HttpGet("autenticado")]
        [Authorize]
        public IActionResult Autenticado()
        {
            return Ok(new { usuario = $"Usuário autenticado: {User.Identity.Name}" });
        }


        [HttpGet("gerente")]
        [Authorize(Roles = "Gerente")]
        public IActionResult DadosGerente()
        {
            return Ok(new { res = "Dados visíveis apenas para gerentes." });
        }


        [HttpGet("funcionarios")]
        [Authorize(Roles = "Gerente,Auxiliar")]
        public IActionResult DadosFuncionarios()
        {
            return Ok(new { res = "Dados visíveis para todos funcionários." });
        }

    }
}
