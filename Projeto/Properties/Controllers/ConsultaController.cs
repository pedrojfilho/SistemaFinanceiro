// Importa os namespaces necessários para o funcionamento do controller

using Microsoft.AspNetCore.Mvc;
using SistemaControleGastos.Models; 
using System.Linq; // Necessário para realizar operações de consulta LINQ
using System.Collections.Generic; // Necessário para usar Listas

namespace SistemaControleGastos.Controllers
{
    // Definir a rota base para as requisições da API

    [Route("api/[controller]")]

    // Indicar que esta classe é um controller da API
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        // Armazenar em memória das pessoas cadastradas
        private static List<Pessoa> pessoas = new List<Pessoa>(); 

        // Armazenar em memória das transações registradas
        private static List<Transacao> transacoes = new List<Transacao>(); 

        // Método que retorna todas as pessoas cadastradas
        // GET: api/consulta/pessoas
        [HttpGet("pessoas")]
        public IActionResult GetPessoas()
        {
            // Verificar se há pessoas cadastradas
            if (pessoas.Any())
            {
                // Retornar as pessoas cadastradas com status OK
                return Ok(pessoas);
            }
            // Caso não haja pessoas cadastradas, retorna status 404 Not Found
            return NotFound("Nenhuma pessoa cadastrada.");
        }

        // Método que retorna uma pessoa pelo seu ID
        // GET: api/consulta/pessoa/{id}
        [HttpGet("pessoa/{id}")]
        public IActionResult GetPessoa(int id)
        {
            // Procurar a pessoa pelo ID informado
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

            // Verificar se a pessoa foi encontrada
            if (pessoa == null)
                // Retornar status 404 Not Found caso a pessoa não seja encontrada
                return NotFound("Pessoa não encontrada.");

            // Retornar a pessoa com status OK
            return Ok(pessoa);
        }

        // Método que retorna todas as transações registradas
        // GET: api/consulta/transacoes
        [HttpGet("transacoes")]
        public IActionResult GetTransacoes()
        {
            // Verificar se há transações cadastradas
            if (transacoes.Any())
            {
                // Retornar as transações com status OK
                return Ok(transacoes);
            }
            // Caso não haja transações registradas, retorna status 404 Not Found
            return NotFound("Nenhuma transação registrada.");
        }

        // Método que retorna uma transação pelo seu ID
        // GET: api/consulta/transacao/{id}
        [HttpGet("transacao/{id}")]
        public IActionResult GetTransacao(int id)
        {
            // Procurar a transação pelo ID informado
            var transacao = transacoes.FirstOrDefault(t => t.Id == id);

            // Verificar se a transação foi encontrada
            if (transacao == null)
                // Retornar status 404 Not Found caso a transação não seja encontrada
                return NotFound("Transação não encontrada.");

            // Retornar a transação com status OK
            return Ok(transacao);
        }

        // Método que retorna todas as transações de uma pessoa específica
        // GET: api/consulta/transacoes/pessoa/{pessoaId}
        [HttpGet("transacoes/pessoa/{pessoaId}")]
        public IActionResult GetTransacoesPorPessoa(int pessoaId)
        {
            // Filtrar as transações da pessoa com o ID fornecido
            var transacoesPessoa = transacoes.Where(t => t.PessoaId == pessoaId).ToList();

            // Verificar se há transações para a pessoa
            if (transacoesPessoa.Any())
            {
                // Retornar as transações da pessoa com status OK
                return Ok(transacoesPessoa);
            }

            // Caso não haja transações para a pessoa, retorna status 404 Not Found
            return NotFound("Nenhuma transação encontrada para esta pessoa.");
        }
    }
}
