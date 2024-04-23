using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosProdutos()
        {
            try
            {
                var produtos = await _produtoService.ObterTodosProdutos();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter produtos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProdutoPorId(int id)
        {
            try
            {
                var produto = await _produtoService.ObterProdutoPorId(id);
                if (produto == null)
                    return NotFound();

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter produto: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarProduto(Produto produto)
        {
            try
            {
                await _produtoService.InserirProduto(produto);
                return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produto.IDProduto }, produto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar produto: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, Produto produto)
        {
            try
            {
                if (id != produto.IDProduto)
                    return BadRequest("ID do produto não corresponde ao ID na URL.");

                await _produtoService.AtualizarProduto(produto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar produto: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverProduto(int id)
        {
            try
            {
                await _produtoService.RemoverProduto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover produto: {ex.Message}");
            }
        }
    }
}
