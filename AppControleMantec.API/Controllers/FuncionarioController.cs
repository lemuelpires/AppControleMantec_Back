using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Application.AppFuncionario.Commands;
using Microsoft.AspNetCore.Mvc;

namespace AppControleMantec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioAppService _funcionarioAppService;

        public FuncionarioController(IFuncionarioAppService funcionarioAppService)
        {
            _funcionarioAppService = funcionarioAppService ?? throw new ArgumentNullException(nameof(funcionarioAppService));
        }

        // GET: api/funcionario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDTO>>> GetFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioAppService.GetFuncionariosAsync();
                return Ok(funcionarios);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar funcionários: {ex.Message}");
            }
        }

        // GET: api/funcionario/5
        [HttpGet("{id}", Name = "GetFuncionarioById")]
        public async Task<ActionResult<FuncionarioDTO>> GetFuncionarioById(string id)
        {
            try
            {
                var funcionario = await _funcionarioAppService.GetFuncionarioByIdAsync(id);
                if (funcionario == null)
                {
                    return NotFound();
                }
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar funcionário: {ex.Message}");
            }
        }

        // POST: api/funcionario
        [HttpPost]
        public async Task<ActionResult<string>> CriarFuncionario([FromBody] FuncionarioCreateCommand command)
        {
            try
            {
                var funcionarioId = await _funcionarioAppService.CriarFuncionarioAsync(command);
                return CreatedAtAction(nameof(GetFuncionarioById), new { id = funcionarioId }, funcionarioId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar funcionário: {ex.Message}");
            }
        }

        // PUT: api/funcionario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFuncionario(string id, [FromBody] FuncionarioUpdateCommand command)
        {
            try
            {
                await _funcionarioAppService.AtualizarFuncionarioAsync(id, command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar funcionário: {ex.Message}");
            }
        }

        // DELETE: api/funcionario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarFuncionario(string id)
        {
            try
            {
                await _funcionarioAppService.DesativarFuncionarioAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar funcionário: {ex.Message}");
            }
        }

        // PUT: api/funcionario/ativar/5
        [HttpPut("ativar/{id}")]
        public async Task<IActionResult> AtivarFuncionario(string id)
        {
            try
            {
                await _funcionarioAppService.AtivarFuncionarioAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao ativar funcionário: {ex.Message}");
            }
        }
    }
}
