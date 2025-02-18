using System;

namespace SistemaControleGastos.Models
{
    // Definir os tipos de transações 0 ou 1
    public enum TipoTransacao
    {
        Despesa,
        Receita
    
    }
    // Definir a classe transação
    public class Transacao
    {
        // Definir os atributos da classe Transação
        public int Id { get; set; } 
        public string Descricao { get; set; } 
        public decimal Valor { get; set; } 
        public TipoTransacao Tipo { get; set; } 
        public int PessoaId { get; set; } // Identificador da pessoa associada a transação
    }
    
     //Construtor que inicializa a transação com uma descrição
    //Se for nulo, realiza excessão ArgumentNullException
    public Transacao(string descricao)
    {
        Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao),"Descrição nao pode ser nulo.");
    }
}