using GestaoOcorrencias.Data;
using GestaoOcorrencias.Data.Models;
using GestaoOcorrencias.Service.Interfaces;
using GestaoOcorrenciasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOcorrenciasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly ApplicationContext _context;

        public ClienteController(IClienteService clienteService, IOcorrenciaService ocorrenciaService, ApplicationContext context)
        {
            _clienteService = clienteService;
            _ocorrenciaService = ocorrenciaService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var clientes = _clienteService.GetAll();
            return Ok(clientes);
        }

        [HttpGet("ocorrencias")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            var clientes = await _context.Clientes
                .Select(c => new ClienteDto { Id = c.Id, Nome = c.Nome })
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult CreateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente é nulo.");
            }

            var clienteResult = _clienteService.Create(cliente);
            return CreatedAtAction(nameof(GetAllClientes), new { id = clienteResult.Id }, clienteResult);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Cliente é nulo.");
            }

            var clienteResult = _clienteService.Update(id, cliente).Result; 

            if (clienteResult == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado.");
            }

            return Ok(clienteResult); // Retorna 200 OK com o cliente atualizado
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            // Verifica se o cliente está vinculado a alguma ocorrência
            if (_ocorrenciaService.ClienteTemOcorrencias(id))
            {
                return BadRequest("O cliente não pode ser excluído porque está vinculado a uma ocorrência.");
            }

            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound($"Cliente com ID {id} não encontrado.");
            }

            _clienteService.Delete(id);
            return NoContent(); // Retorna 204 No Content
        }
    }
}
