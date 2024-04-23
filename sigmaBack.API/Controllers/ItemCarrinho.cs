using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using SigmaBack.Domain.Interfaces;
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
        public async Task<IActionResult> AdicionarItemCarrinho(ItemCarrinho itemCarrinho)
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
        public async Task<IActionResult> Put(int id, ItemCarrinho itemCarrinho)
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
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
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
