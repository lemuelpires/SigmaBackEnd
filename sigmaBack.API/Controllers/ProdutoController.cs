using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(Summary = "Obtém todos os produtos.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os produtos.", typeof(IEnumerable<Produto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
        [SwaggerOperation(Summary = "Obtém um produto por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Produto encontrado.", typeof(Produto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Produto não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
        [SwaggerOperation(Summary = "Cria um novo produto.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Produto criado com sucesso.", typeof(Produto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro de solicitação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> CriarProduto([FromBody] Produto produto)
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
        [SwaggerOperation(Summary = "Atualiza um produto.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Produto atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro de solicitação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produto)
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
        [SwaggerOperation(Summary = "Remove um produto.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Produto removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
//