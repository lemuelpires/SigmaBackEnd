using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(Summary = "Obtém todos os itens do pedido.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os itens do pedido.", typeof(IEnumerable<ItemPedido>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> Get()
        {
            var itensPedido = await _itemPedidoService.ObterTodosItensPedido();
            return Ok(itensPedido);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um item do pedido por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Item do pedido encontrado.", typeof(ItemPedido))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do pedido não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
        [SwaggerOperation(Summary = "Cria um novo item do pedido.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Item do pedido criado com sucesso.", typeof(ItemPedido))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro de solicitação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<ActionResult<ItemPedido>> Post([FromBody] ItemPedido itemPedido)
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
        [SwaggerOperation(Summary = "Atualiza um item do pedido.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do pedido atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "O ID do item do pedido não corresponde ao ID na URL.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> Put(int id, [FromBody] ItemPedido itemPedido)
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
        [SwaggerOperation(Summary = "Remove um item do pedido.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do pedido removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro de solicitação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
//