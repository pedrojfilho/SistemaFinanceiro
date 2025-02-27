using Microsoft.EntityFrameworkCore;
using ProjetoFinanceiro.Models;

namespace ProjetoFinanceiro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)  // Construtor que recebe as opções do DbContext
        {
        }

        // Definindo as tabelas do banco de dados
        public DbSet<Usuario> Usuarios { get; set; } = null!;   // Tabela de Usuarios
        public DbSet<Categoria> Categorias { get; set; } = null!; // Tabela de Categorias
        public DbSet<Transacao> Transacoes { get; set; } = null!; // Tabela de Transacoes

        // Configuração de relacionamentos e restrições
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento entre Usuario e Categoria
            modelBuilder.Entity<Categoria>()
                .HasOne(c => c.Usuario)  // Uma Categoria pertence a um Usuario
                .WithMany(u => u.Categorias)  // Um Usuario pode ter muitas Categorias
                .HasForeignKey(c => c.UsuarioId);  // Chave estrangeira em Categoria

            // Configuração do relacionamento entre Categoria e Transacao
            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Categoria)  // Uma Transacao pertence a uma Categoria
                .WithMany(c => c.Transacoes)  // Uma Categoria pode ter muitas Transacoes
                .HasForeignKey(t => t.CategoriaId);  // Chave estrangeira em Transacao

            // Configuração do relacionamento entre Usuario e Transacao
            modelBuilder.Entity<Transacao>()
                .HasOne(t => t.Usuario)  // Uma Transacao pertence a um Usuario
                .WithMany(u => u.Transacoes)  // Um Usuario pode ter muitas Transacoes
                .HasForeignKey(t => t.UsuarioId);  // Chave estrangeira em Transacao

            // Exemplo: Configurar um índice único para o e-mail do usuário
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}