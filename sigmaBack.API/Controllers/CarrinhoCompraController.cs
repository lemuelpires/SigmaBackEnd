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
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraService _carrinhoCompraService;

        public CarrinhoCompraController(ICarrinhoCompraService carrinhoCompraService)
        {
            _carrinhoCompraService = carrinhoCompraService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosCarrinhos()
        {
            try
            {
                var carrinhos = await _carrinhoCompraService.ObterTodosCarrinhos();
                return Ok(carrinhos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter carrinhos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCarrinhoPorId(int id)
        {
            try
            {
                var carrinho = await _carrinhoCompraService.ObterCarrinhoPorId(id);
                if (carrinho == null)
                    return NotFound();

                return Ok(carrinho);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter carrinho: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovoCarrinho(CarrinhoCompra carrinho)
        {
            try
            {
                var idCarrinho = await _carrinhoCompraService.CriarNovoCarrinho(carrinho);
                return CreatedAtAction(nameof(ObterCarrinhoPorId), new { id = idCarrinho }, carrinho);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar carrinho: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCarrinho(int id, CarrinhoCompra carrinho)
        {
            try
            {
                await _carrinhoCompraService.AtualizarCarrinho(carrinho);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar carrinho: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCarrinho(int id)
        {
            try
            {
                await _carrinhoCompraService.RemoverCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover carrinho: {ex.Message}");
            }
        }
    }
}
