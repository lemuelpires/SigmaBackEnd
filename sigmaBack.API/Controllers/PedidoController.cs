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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os pedidos.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os pedidos.", typeof(IEnumerable<Pedido>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterTodosPedidos()
        {
            try
            {
                var pedidos = await _pedidoService.ObterTodosPedidos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter pedidos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um pedido por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Pedido encontrado.", typeof(Pedido))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Pedido não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterPedidoPorId(int id)
        {
            try
            {
                var pedido = await _pedidoService.ObterPedidoPorId(id);
                if (pedido == null)
                    return NotFound();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter pedido: {ex.Message}");
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo pedido.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Pedido criado com sucesso.", typeof(Pedido))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro de solicitação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> CriarPedido([FromBody] Pedido pedido)
        {
            try
            {
                var idPedido = await _pedidoService.CriarPedido(pedido);
                return CreatedAtAction(nameof(ObterPedidoPorId), new { id = idPedido }, pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar pedido: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um pedido.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Pedido atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody] Pedido pedido)
        {
            try
            {
                await _pedidoService.AtualizarPedido(id, pedido);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar pedido: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um pedido.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Pedido removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> RemoverPedido(int id)
        {
            try
            {
                await _pedidoService.RemoverPedido(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover pedido: {ex.Message}");
            }
        }
    }
}
