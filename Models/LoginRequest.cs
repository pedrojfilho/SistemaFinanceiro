using ProjetoFinanceiro.Data;

namespace ProjetoFinanceiro.Models

{
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
