using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaAutenticacao.Data;
using SistemaAutenticacao.Models;
using SistemaAutenticacao.Services;

namespace SistemaAutenticacao.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioData _usuarios = new UsuarioData();


        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] Usuario body)
        {
            var usuario = _usuarios.Get(body.Username, body.Senha);
            
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
        public async Task<IActionResult> Autenticado ()
        {
            return Ok(new { usuario = $"Usuário autenticado: {User.Identity.Name}" });
        }


        [HttpGet("gerente")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> DadosGerente ()
        {
            return Ok(new { res = "Dados visíveis apenas para gerentes." });
        }


        [HttpGet("funcionarios")]
        [Authorize(Roles = "Gerente,Auxiliar")]
        public async Task<IActionResult> DadosFuncionarios()
        {
            return Ok(new { res = "Dados visíveis para todos funcionários." });
        }

    }
}
