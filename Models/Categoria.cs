using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinanceiro.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome da categoria deve ter no máximo 50 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O tipo da categoria é obrigatório.")]
        [RegularExpression("^(renda|despesa)$", ErrorMessage = "O tipo deve ser 'renda' ou 'despesa'.")]
        public required string Tipo { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        // Propriedade de navegação para Transacoes
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}