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
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraService _carrinhoCompraService;

        public CarrinhoCompraController(ICarrinhoCompraService carrinhoCompraService)
        {
            _carrinhoCompraService = carrinhoCompraService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os carrinhos de compra.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os carrinhos de compra.", typeof(IEnumerable<CarrinhoCompra>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
        [SwaggerOperation(Summary = "Obtém um carrinho de compra por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Carrinho de compra encontrado.", typeof(CarrinhoCompra))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho de compra não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
        [SwaggerOperation(Summary = "Cria um novo carrinho de compra.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Carrinho de compra criado com sucesso.", typeof(CarrinhoCompra))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> CriarNovoCarrinho([FromBody] CarrinhoCompra carrinho)
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
        [SwaggerOperation(Summary = "Atualiza um carrinho de compra existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho de compra atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AtualizarCarrinho(int id, [FromBody] CarrinhoCompra carrinho)
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
        [SwaggerOperation(Summary = "Remove um carrinho de compra existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho de compra removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
//