using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraService _carrinhoService;

        public CarrinhoCompraController(ICarrinhoCompraService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de carrinhos de compra")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de carrinhos de compra", typeof(IEnumerable<CarrinhoCompra>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<CarrinhoCompra>>> Get()
        {
            var carrinhos = await _carrinhoService.ObterTodosCarrinhos();
            return Ok(carrinhos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um carrinho de compra por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o carrinho de compra encontrado", typeof(CarrinhoCompra))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho de compra não encontrado")]
        public async Task<ActionResult<CarrinhoCompra>> GetById(int id)
        {
            var carrinho = await _carrinhoService.ObterCarrinhoPorId(id);
            if (carrinho == null)
            {
                return NotFound();
            }
            return Ok(carrinho);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo carrinho de compra")]
        [SwaggerResponse(StatusCodes.Status201Created, "Carrinho de compra criado com sucesso", typeof(CarrinhoCompra))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<CarrinhoCompra>> Post(CarrinhoCompra carrinho)
        {
            try
            {
                var createdCarrinhoId = await _carrinhoService.CriarNovoCarrinho(carrinho);
                var createdCarrinho = await _carrinhoService.ObterCarrinhoPorId(createdCarrinhoId);
                return CreatedAtAction(nameof(GetById), new { id = createdCarrinhoId }, createdCarrinho);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um carrinho de compra existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho de compra atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho de compra não encontrado")]
        public async Task<IActionResult> Put(int id, CarrinhoCompra carrinho)
        {
            if (id != carrinho.IDCarrinho)
            {
                return BadRequest("ID do carrinho de compra não corresponde ao ID na URL.");
            }

            try
            {
                await _carrinhoService.AtualizarCarrinho(carrinho);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um carrinho de compra existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho de compra desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho de compra não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _carrinhoService.DesabilitarCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um carrinho de compra existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho de compra habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho de compra não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _carrinhoService.HabilitarCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
