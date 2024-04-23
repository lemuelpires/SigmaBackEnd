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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
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
        public async Task<IActionResult> CriarPedido(Pedido pedido)
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
        public async Task<IActionResult> AtualizarPedido(int id, Pedido pedido)
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

