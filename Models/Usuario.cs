using System.ComponentModel.DataAnnotations;

namespace ProjetoFinanceiro.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string SenhaHash { get; set; } = null!;

        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}