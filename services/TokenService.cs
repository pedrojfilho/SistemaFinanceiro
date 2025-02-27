using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProjetoFinanceiro.Models;

namespace ProjetoFinanceiro.Services
{
    public class TokenService : ITokenService
    {
        private readonly string _key;

        public TokenService(string key)
        {
            // Verifica se a chave tem pelo menos 32 caracteres
            if (string.IsNullOrEmpty(key) || key.Length < 32)
            {
                throw new ArgumentException("A chave JWT deve ter pelo menos 32 caracteres.");
            }
            _key = key;
        }

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key); // Converte a chave para bytes

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expira em 1 hora
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), // Usa a chave fornecida
                    SecurityAlgorithms.HmacSha256Signature) // Algoritmo de assinatura
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}