using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Obtém a lista de itens do pedido")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de itens do pedido", typeof(IEnumerable<ItemPedido>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> Get()
        {
            var itensPedido = await _itemPedidoService.ObterTodosItensPedido();
            return Ok(itensPedido);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um item do pedido por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o item do pedido encontrado", typeof(ItemPedido))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do pedido não encontrado")]
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
        [SwaggerOperation(Summary = "Adiciona um novo item ao pedido")]
        [SwaggerResponse(StatusCodes.Status201Created, "Item do pedido adicionado com sucesso", typeof(ItemPedido))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<ItemPedido>> Post(ItemPedido itemPedido)
        {
            try
            {
                var createdItemId = await _itemPedidoService.CriarNovoItemPedido(itemPedido);
                var createdItem = await _itemPedidoService.ObterItemPedidoPorId(createdItemId);
                return CreatedAtAction(nameof(GetById), new { id = createdItemId }, createdItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um item do pedido existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do pedido atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do pedido não encontrado")]
        public async Task<IActionResult> Put(int id, ItemPedido itemPedido)
        {
            if (id != itemPedido.IDItemPedido)
            {
                return BadRequest("ID do item do pedido não corresponde ao ID na URL.");
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

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um item do pedido existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do pedido desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do pedido não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _itemPedidoService.DesabilitarItemPedido(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um item do pedido existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do pedido habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do pedido não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _itemPedidoService.HabilitarItemPedido(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
