using Microsoft.AspNetCore.Mvc;
using SistemaControleGastos.Models; 
using System.Collections.Generic; 
using System.Linq; 

namespace SistemaControleGastos.Controllers
{
    [Route("api/[controller]")]
    
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private static List<Transacao> transacoes = new List<Transacao>(); 

        // Método para criar uma nova transação
        // POST: api/transacao
        [HttpPost]
        public IActionResult CreateTransacao([FromBody] Transacao transacao)
        {
            // Verificar se os dados enviados são válidos
            if (transacao == null)
                // Retornar erro 400 BadRequest se os dados estiverem inválidos
                return BadRequest("Dados inválidos.");

            // Gerar um ID único para a nova transação. Se houver transações cadastradas, aumenta o ID.
            transacao.Id = transacoes.Count > 0 ? transacoes.Max(t => t.Id) + 1 : 1;

            // Adicionar a transação à lista de transações
            transacoes.Add(transacao);

            // Retornar status 201 Created e os dados da transação criada
            return CreatedAtAction(nameof(GetTransacao), new { id = transacao.Id }, transacao);
        }

        // Método para buscar uma transação pelo seu ID
        // GET: api/transacao/{id}
        [HttpGet("{id}")]
        public IActionResult GetTransacao(int id)
        {
            // Procurar a transação pelo ID informado
            var transacao = transacoes.FirstOrDefault(t => t.Id == id);

            // Verificar se a transação foi encontrada
            if (transacao == null)
                // Retornar status 404 NotFound caso a transação não seja encontrada
                return NotFound();

            // Retorna a transação encontrada com status OK
            return Ok(transacao);
        }

        // Método para buscar todas as transações registradas
        // GET: api/transacao
        [HttpGet]
        public IActionResult GetTransacoes()
        {
            // Retornar todas as transações registradas com status OK
            return Ok(transacoes);
        }
    }
}
