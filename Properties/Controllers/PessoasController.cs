// Importa os namespaces necessários para o funcionamento do controller
using Microsoft.AspNetCore.Mvc;
using SistemaControleGastos.Models; 
using System.Collections.Generic; 
using System.Linq; 

namespace SistemaControleGastos.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class PessoaController : ControllerBase
    {
        // Armazenar em memória das pessoas cadastradas
        private static List<Pessoa> pessoas = new List<Pessoa>(); 

        // Método para criar uma nova pessoa
        // POST: api/pessoa
        [HttpPost]
        public IActionResult CreatePessoa([FromBody] Pessoa pessoa)
        {
            // Verificar se os dados enviados são válidos
            if (pessoa == null)
                // Retornar erro 400 BadRequest se os dados estiverem inválidos
                return BadRequest("Dados inválidos.");

            // Gerar um ID único para a nova pessoa. Se houver pessoas cadastradas, aumenta o ID.
            pessoa.Id = pessoas.Count > 0 ? pessoas.Max(p => p.Id) + 1 : 1;

            // Adicionar a pessoa à lista de pessoas cadastradas
            pessoas.Add(pessoa);

            // Retornar status Created e os dados da pessoa criada
            return CreatedAtAction(nameof(GetPessoa), new { id = pessoa.Id }, pessoa);
        }

        // Método para buscar uma pessoa pelo seu ID
        // GET: api/pessoa/{id}
        [HttpGet("{id}")]
        public IActionResult GetPessoa(int id)
        {
            // Procurar a pessoa pelo ID informado
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);

            // Verificar se a pessoa foi encontrada
            if (pessoa == null)
                // Retornar status 404 NotFound caso a pessoa não seja encontrada
                return NotFound();

            // Retorna a pessoa encontrada com status OK
            return Ok(pessoa);
        }

        // Método para buscar todas as pessoas cadastradas
        // GET: api/pessoa
        [HttpGet]
        public IActionResult GetPessoas()
        {
            // Retornar todas as pessoas cadastradas com status  OK
            return Ok(pessoas);
        }
    }
}
