using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Application.AppEstoque.Commands;
using Microsoft.AspNetCore.Mvc;

namespace AppControleMantec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueAppService _estoqueAppService;

        public EstoqueController(IEstoqueAppService estoqueAppService)
        {
            _estoqueAppService = estoqueAppService ?? throw new ArgumentNullException(nameof(estoqueAppService));
        }

        // GET: api/estoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstoqueDTO>>> GetEstoques()
        {
            try
            {
                var estoques = await _estoqueAppService.GetEstoquesAsync();
                return Ok(estoques);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar estoques: {ex.Message}");
            }
        }

        // GET: api/estoque/5
        [HttpGet("{id:length(24)}", Name = "GetEstoqueById")]
        public async Task<ActionResult<EstoqueDTO>> GetEstoqueById(string id)
        {
            try
            {
                var estoque = await _estoqueAppService.GetEstoqueByIdAsync(id);
                if (estoque == null)
                {
                    return NotFound();
                }
                return Ok(estoque);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar estoque: {ex.Message}");
            }
        }

        // POST: api/estoque
        [HttpPost]
        public async Task<ActionResult<string>> CriarEstoque([FromBody] EstoqueCreateCommand command)
        {
            try
            {
                var estoqueId = await _estoqueAppService.CriarEstoqueAsync(command);
                return CreatedAtAction(nameof(GetEstoqueById), new { id = estoqueId }, estoqueId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar estoque: {ex.Message}");
            }
        }

        // PUT: api/estoque/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> AtualizarEstoque(string id, [FromBody] EstoqueUpdateCommand command)
        {
            try
            {
                await _estoqueAppService.AtualizarEstoqueAsync(id, command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar estoque: {ex.Message}");
            }
        }

        // DELETE: api/estoque/5
        [HttpPut("desativar/{id:length(24)}")]
        public async Task<IActionResult> DesativarEstoque(string id)
        {
            try
            {
                await _estoqueAppService.DesativarEstoqueAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar estoque: {ex.Message}");
            }
        }

        // PUT: api/estoque/ativar/5
        [HttpPut("ativar/{id:length(24)}")]
        public async Task<IActionResult> AtivarEstoque(string id)
        {
            try
            {
                await _estoqueAppService.AtivarEstoqueAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao ativar estoque: {ex.Message}");
            }
        }
    }
}
