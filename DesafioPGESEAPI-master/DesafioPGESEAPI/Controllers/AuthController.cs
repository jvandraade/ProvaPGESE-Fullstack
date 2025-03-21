using DesafioPGESE.Application.Services;
using DesafioPGESE.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPGESEAPI.API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly JwtService _jwtService;

        public AuthController(IUsuarioService usuarioService, JwtService jwtService)
        {
            _usuarioService = usuarioService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Authenticate a user and create a token JWT.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            Console.WriteLine("Teste");
            var usuario = await _usuarioService.AuthenticateAsync(request.CPF, request.Password);

            if (usuario == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos." });

            var token = _jwtService.GenerateToken(usuario);
            return Ok(new { Usuario = usuario, Token = token, Tipo = usuario.Tipo });

        }
    }

    public class LoginRequest
    {
        public string CPF { get; set; }
        public string Password { get; set; }
    }

}
