using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de pedidos")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de pedidos", typeof(IEnumerable<Pedido>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            var pedidos = await _pedidoService.ObterTodosPedidos();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um pedido por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o pedido encontrado", typeof(Pedido))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pedido não encontrado")]
        public async Task<ActionResult<Pedido>> GetById(int id)
        {
            var pedido = await _pedidoService.ObterPedidoPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo pedido")]
        [SwaggerResponse(StatusCodes.Status201Created, "Pedido criado com sucesso", typeof(Pedido))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Pedido>> Post(Pedido pedido)
        {
            try
            {
                var createdPedidoId = await _pedidoService.CriarPedido(pedido);
                var createdPedido = await _pedidoService.ObterPedidoPorId(createdPedidoId);
                return CreatedAtAction(nameof(GetById), new { id = createdPedidoId }, createdPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um pedido existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Pedido atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pedido não encontrado")]
        public async Task<IActionResult> Put(int id, Pedido pedido)
        {
            if (id != pedido.IDPedido)
            {
                return BadRequest("ID do pedido não corresponde ao ID na URL.");
            }

            try
            {
                await _pedidoService.AtualizarPedido(id, pedido);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um pedido existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Pedido desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pedido não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _pedidoService.DesabilitarPedido(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um pedido existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Pedido habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pedido não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _pedidoService.HabilitarPedido(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
