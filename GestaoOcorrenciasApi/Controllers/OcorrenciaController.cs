using GestaoOcorrencias.Data;
using GestaoOcorrencias.Data.Models;
using GestaoOcorrencias.Service.Interfaces;
using GestaoOcorrenciasApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOcorrenciasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaService _ocorrenciaService;
        private readonly ApplicationContext _context;

        public OcorrenciaController(IOcorrenciaService ocorrenciaService, ApplicationContext context)
        {
            _ocorrenciaService = ocorrenciaService;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllOcorrencias()
        {
            var clientes = _ocorrenciaService.GetAll();
            return Ok(clientes);
        }

        [HttpGet("detalhe")]
        public IActionResult GetAllOcorrenciasDetalhe()
        {
            var clientes = _ocorrenciaService.GetAllDto();
            return Ok(clientes);
        }


        [HttpPost]
        public IActionResult CreateOcorrencia([FromBody] Ocorrencia ocorrencia)
        {
            if (ocorrencia == null)
            {
                return BadRequest("Ocorrencia é nulo.");
            }

            var ocorrenciaResult = _ocorrenciaService.CreateWhitReturnDto(ocorrencia);
            return CreatedAtAction(nameof(GetAllOcorrenciasDetalhe), new { id = ocorrenciaResult.Id }, ocorrenciaResult);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOcorrencia(int id, [FromBody] Ocorrencia ocorrencia)
        {
            if (ocorrencia == null)
            {
                return BadRequest("Ocorrência é nula.");
            }

            var ocorrenciaResult = _ocorrenciaService.Update(id, ocorrencia).Result;

            if (ocorrenciaResult == null)
            {
                return NotFound($"Ocorrência com ID {id} não encontrada.");
            }

            return Ok(ocorrenciaResult); // Retorna 200 OK com o cliente atualizado
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOcorrencia(int id)
        {
            var ocorrencia = _ocorrenciaService.GetById(id);

            if (ocorrencia == null)
            {
                return NotFound($"Ocorrência com ID {id} não encontrada.");
            }

            _ocorrenciaService.Delete(id);
            return NoContent(); // Retorna 204 No Content
        }
    }
}
