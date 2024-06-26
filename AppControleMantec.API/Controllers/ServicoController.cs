using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppControleMantec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoAppService _servicoAppService;
        private readonly ILogger<ServicoController> _logger;

        public ServicoController(IServicoAppService servicoAppService, ILogger<ServicoController> logger)
        {
            _servicoAppService = servicoAppService ?? throw new ArgumentNullException(nameof(servicoAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/servico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoDTO>>> GetServicos()
        {
            try
            {
                var servicos = await _servicoAppService.GetServicosAsync();
                return Ok(servicos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao recuperar serviços: {ex.Message}");
                return BadRequest($"Erro ao recuperar serviços: {ex.Message}");
            }
        }

        // GET: api/servico/5
        [HttpGet("{id:length(24)}", Name = "GetServicoById")]
        public async Task<ActionResult<ServicoDTO>> GetServicoById(string id)
        {
            try
            {
                var servico = await _servicoAppService.GetServicoByIdAsync(id);
                if (servico == null)
                {
                    return NotFound();
                }
                return Ok(servico);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao recuperar serviço: {ex.Message}");
                return BadRequest($"Erro ao recuperar serviço: {ex.Message}");
            }
        }

        // POST: api/servico
        [HttpPost]
        public async Task<ActionResult<string>> CriarServico([FromBody] ServicoDTO servicoDto)
        {
            try
            {
                if (servicoDto == null)
                {
                    return BadRequest("Dados do serviço inválidos.");
                }

                var servicoId = await _servicoAppService.InsertServicoAsync(servicoDto);
                return CreatedAtAction(nameof(GetServicoById), new { id = servicoId }, servicoId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar serviço: {ex.Message}");
                return BadRequest($"Erro ao criar serviço: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarServico(string id, [FromBody] ServicoDTO servicoDto)
        {
            try
            {
                await _servicoAppService.UpdateServicoAsync(servicoDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        // DELETE: api/servico/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DesativarServico(string id)
        {
            try
            {
                await _servicoAppService.DesativarServicoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao desativar serviço: {ex.Message}");
                return BadRequest($"Erro ao desativar serviço: {ex.Message}");
            }
        }

        // PUT: api/servico/ativar/5
        [HttpPut("ativar/{id:length(24)}")]
        public async Task<IActionResult> AtivarServico(string id)
        {
            try
            {
                await _servicoAppService.AtivarServicoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao ativar serviço: {ex.Message}");
                return BadRequest($"Erro ao ativar serviço: {ex.Message}");
            }
        }
    }
}
