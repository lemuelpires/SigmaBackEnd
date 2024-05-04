using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
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
        [SwaggerOperation(Summary = "Obtém a lista de itens do carrinho")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de itens do carrinho", typeof(IEnumerable<ItemCarrinho>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<ItemCarrinho>>> Get()
        {
            var itensCarrinho = await _itemCarrinhoService.ObterTodosItensCarrinho();
            return Ok(itensCarrinho);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um item do carrinho por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o item do carrinho encontrado", typeof(ItemCarrinho))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do carrinho não encontrado")]
        public async Task<ActionResult<ItemCarrinho>> GetById(int id)
        {
            var itemCarrinho = await _itemCarrinhoService.ObterItemCarrinhoPorId(id);
            if (itemCarrinho == null)
            {
                return NotFound();
            }
            return Ok(itemCarrinho);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo item ao carrinho")]
        [SwaggerResponse(StatusCodes.Status201Created, "Item do carrinho adicionado com sucesso", typeof(ItemCarrinho))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<ItemCarrinho>> Post(ItemCarrinho itemCarrinho)
        {
            try
            {
                var createdItemId = await _itemCarrinhoService.AdicionarItemCarrinho(itemCarrinho);
                var createdItem = await _itemCarrinhoService.ObterItemCarrinhoPorId(createdItemId);
                return CreatedAtAction(nameof(GetById), new { id = createdItemId }, createdItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um item do carrinho existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do carrinho atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do carrinho não encontrado")]
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

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um item do carrinho existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do carrinho desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do carrinho não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _itemCarrinhoService.DesabilitarItemCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um item do carrinho existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Item do carrinho habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Item do carrinho não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _itemCarrinhoService.HabilitarItemCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
