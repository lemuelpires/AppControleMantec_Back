using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Application.AppCliente.Commands;
using Microsoft.AspNetCore.Mvc;

namespace AppControleMantec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService ?? throw new ArgumentNullException(nameof(clienteAppService));
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var clientes = await _clienteAppService.GetClientesPaginadosAsync(page, pageSize);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar clientes: {ex.Message}");
            }
        }

        // GET: api/cliente/{id}
        [HttpGet("{id:length(24)}", Name = "GetClienteById")]
        public async Task<ActionResult<ClienteDTO>> GetClienteById(string id)
        {
            try
            {
                var cliente = await _clienteAppService.GetClienteByIdAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar cliente: {ex.Message}");
            }
        }

        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult<string>> CriarCliente([FromBody] ClienteCreateCommand command)
        {
            try
            {
                var clienteId = await _clienteAppService.CriarClienteAsync(command);
                return CreatedAtAction(nameof(GetClienteById), new { id = clienteId }, clienteId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar cliente: {ex.Message}");
            }
        }

        // PUT: api/cliente/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> AtualizarCliente(string id, [FromBody] ClienteUpdateCommand command)
        {
            try
            {
                await _clienteAppService.AtualizarClienteAsync(id, command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar cliente: {ex.Message}");
            }
        }

        // DELETE: api/cliente/{id}
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DesativarCliente(string id)
        {
            try
            {
                await _clienteAppService.DesativarClienteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar cliente: {ex.Message}");
            }
        }

        // PUT: api/cliente/ativar/{id}
        [HttpPut("ativar/{id:length(24)}")]
        public async Task<IActionResult> AtivarCliente(string id)
        {
            try
            {
                await _clienteAppService.AtivarClienteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao ativar cliente: {ex.Message}");
            }
        }
    }
}
