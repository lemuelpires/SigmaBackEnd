using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCarrinhoController : ControllerBase
    {
        private readonly IItemCarrinhoService _itemCarrinhoService;

        public ItemCarrinhoController(IItemCarrinhoService itemCarrinhoService)
        {
            _itemCarrinhoService = itemCarrinhoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os itens do carrinho.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os itens do carrinho.", typeof(IEnumerable<ItemCarrinho>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterTodosItensCarrinho()
        {
            try
            {
                var itensCarrinho = await _itemCarrinhoService.ObterTodosItensCarrinho();
                return Ok(itensCarrinho);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter itens do carrinho: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um item do carrinho por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item do carrinho encontrado.", typeof(ItemCarrinho))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do carrinho não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterItemCarrinhoPorId(int id)
        {
            try
            {
                var itemCarrinho = await _itemCarrinhoService.ObterItemCarrinhoPorId(id);
                if (itemCarrinho == null)
                    return NotFound();

                return Ok(itemCarrinho);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter item do carrinho: {ex.Message}");
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo item ao carrinho.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Item do carrinho adicionado com sucesso.", typeof(ItemCarrinho))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AdicionarItemCarrinho([FromBody] ItemCarrinho itemCarrinho)
        {
            try
            {
                var idItemCarrinho = await _itemCarrinhoService.AdicionarItemCarrinho(itemCarrinho);
                return CreatedAtAction(nameof(ObterItemCarrinhoPorId), new { id = idItemCarrinho }, itemCarrinho);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar item ao carrinho: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um item do carrinho.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do carrinho atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "O ID do item do carrinho não corresponde ao ID na URL.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AtualizarItemCarrinho(int id, [FromBody] ItemCarrinho itemCarrinho)
        {
            if (id != itemCarrinho.IDItemCarrinho)
            {
                return BadRequest("ID do item do carrinho não corresponde ao ID na URL.");
            }

            try
            {
                await _itemCarrinhoService.AtualizarItemCarrinho(itemCarrinho);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar item do carrinho: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um item do carrinho.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do carrinho removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> RemoverItemCarrinho(int id)
        {
            try
            {
                await _itemCarrinhoService.RemoverItemCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover item do carrinho: {ex.Message}");
            }
        }
    }
}
