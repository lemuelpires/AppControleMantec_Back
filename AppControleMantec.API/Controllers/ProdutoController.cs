using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppControleMantec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService ?? throw new ArgumentNullException(nameof(produtoAppService));
        }

        // GET: api/produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutos()
        {
            try
            {
                var produtos = await _produtoAppService.GetProdutosAsync();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar produtos: {ex.Message}");
            }
        }

        // GET: api/produto/5
        [HttpGet("{id}", Name = "GetProdutoById")]
        public async Task<ActionResult<ProdutoDTO>> GetProdutoById(string id)
        {
            try
            {
                var produto = await _produtoAppService.GetProdutoByIdAsync(id);
                if (produto == null)
                {
                    return NotFound();
                }
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar produto: {ex.Message}");
            }
        }

        // POST: api/produto
        [HttpPost]
        public async Task<ActionResult<string>> CriarProduto([FromBody] ProdutoDTO produtoDto)
        {
            try
            {
                // Crie o produto e obtenha o ID gerado
                var produtoId = await _produtoAppService.InsertProdutoAsync(produtoDto);

                // Retorne a resposta com o CreatedAtAction
                return CreatedAtAction(nameof(GetProdutoById), new { id = produtoId }, produtoId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar produto: {ex.Message}");
            }
        }

        // PUT: api/produto/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(string id, [FromBody] ProdutoDTO produtoDto)
        {
            try
            {
                await _produtoAppService.UpdateProdutoAsync(produtoDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar produto: {ex.Message}");
            }
        }

        // DELETE: api/produto/5
        [HttpDelete("desativar/{id}")]
        public async Task<IActionResult> DesativarProduto(string id)
        {
            try
            {
                await _produtoAppService.DesativarProdutoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar produto: {ex.Message}");
            }
        }

        // PUT: api/produto/ativar/5
        [HttpPut("ativar/{id}")]
        public async Task<IActionResult> AtivarProduto(string id)
        {
            try
            {
                await _produtoAppService.AtivarProdutoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao ativar produto: {ex.Message}");
            }
        }
    }
}
