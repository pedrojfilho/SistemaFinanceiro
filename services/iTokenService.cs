using ProjetoFinanceiro.Models;
using ProjetoFinanceiro.Data;

namespace ProjetoFinanceiro.Services
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
    }
}
