using System;

namespace SistemaControleGastos.Models
{
    // Definir a classe pessoa
    public class Pessoa
    {
        // Definir os atributos da classe Pessoa
        public int Id {get; set;}
        public string Nome {get; set;}
        public int Idade {get; set;}
    }

    //Construtor que inicializa a pessoa com nome e idade
    //Se for nulo, realiza excessão ArgumentNullException
    public Pessoa (string nome, int idade)
    {
        Nome = nome ?? throw new ArgumentNullException (nameof(nome), "Nome não pode ser nulo");
        Idade = idade;
    }
}