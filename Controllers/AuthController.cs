using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Data;
using ProjetoFinanceiro.Models;
using ProjetoFinanceiro.Services;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace ProjetoFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly AppDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ITokenService tokenService, AppDbContext context, ILogger<AuthController> logger)
        {
            _tokenService = tokenService;
            _context = context;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                _logger.LogInformation("Tentativa de login com e-mail: {Email}", request.Email);

                // Verifica se o e-mail e a senha foram fornecidos
                if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Senha))
                {
                    _logger.LogWarning("E-mail ou senha não fornecidos.");
                    return BadRequest("E-mail e senha são obrigatórios.");
                }

                // Busca o usuário no banco de dados
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == request.Email);
                if (usuario == null)
                {
                    _logger.LogWarning("Usuário não encontrado para o e-mail: {Email}", request.Email);
                    return Unauthorized("E-mail ou senha inválidos.");
                }

                // Verifica a senha (substitua por uma lógica de hash real)
                if (usuario.SenhaHash != request.Senha)
                {
                    _logger.LogWarning("Senha incorreta para o e-mail: {Email}", request.Email);
                    return Unauthorized("E-mail ou senha inválidos.");
                }

                // Gera o token JWT
                var token = _tokenService.GerarToken(usuario);
                _logger.LogInformation("Login bem-sucedido para o e-mail: {Email}", request.Email);

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar o login para o e-mail: {Email}", request.Email);
                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }
        }
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}