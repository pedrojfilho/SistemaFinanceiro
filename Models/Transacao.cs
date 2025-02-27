using System.ComponentModel.DataAnnotations;

namespace ProjetoFinanceiro.Models
{
    public class Transacao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O valor da transação é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data da transação é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O ID da categoria é obrigatório.")]
        public int CategoriaId { get; set; }

        // Propriedade de navegação para Categoria
        public Categoria? Categoria { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public int UsuarioId { get; set; }

        // Propriedade de navegação para Usuario
        public Usuario? Usuario { get; set; }
    }
}