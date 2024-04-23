using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IItemPedidoService _itemPedidoService;

        public ItemPedidoController(IItemPedidoService itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> Get()
        {
            var itensPedido = await _itemPedidoService.ObterTodosItensPedido();
            return Ok(itensPedido);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPedido>> GetById(int id)
        {
            var itemPedido = await _itemPedidoService.ObterItemPedidoPorId(id);
            if (itemPedido == null)
            {
                return NotFound();
            }
            return Ok(itemPedido);
        }

        [HttpPost]
        public async Task<ActionResult<ItemPedido>> Post(ItemPedido itemPedido)
        {
            try
            {
                var createdItemPedidoId = await _itemPedidoService.CriarNovoItemPedido(itemPedido);
                return CreatedAtAction(nameof(GetById), new { id = createdItemPedidoId }, itemPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ItemPedido itemPedido)
        {
            if (id != itemPedido.IDItemPedido)
            {
                return BadRequest("ID do item de pedido não corresponde ao ID na URL.");
            }

            try
            {
                await _itemPedidoService.AtualizarItemPedido(id, itemPedido);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _itemPedidoService.RemoverItemPedido(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
