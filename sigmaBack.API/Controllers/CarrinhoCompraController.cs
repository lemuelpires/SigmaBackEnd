using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoCompraController : ControllerBase
    {
        private readonly ICarrinhoCompraRepository _carrinhoCompraRepository;

        public CarrinhoCompraController(ICarrinhoCompraRepository carrinhoCompraRepository)
        {
            _carrinhoCompraRepository = carrinhoCompraRepository ?? throw new ArgumentNullException(nameof(carrinhoCompraRepository));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de carrinhos de compra")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de carrinhos de compra", typeof(IEnumerable<CarrinhoCompra>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<CarrinhoCompra>>> ObterTodosCarrinhos()
        {
            var carrinhos = await _carrinhoCompraRepository.ObterTodosCarrinhos();
            return Ok(carrinhos);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obtém um carrinho de compra por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o carrinho de compra encontrado", typeof(CarrinhoCompra))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho não encontrado")]
        public async Task<ActionResult<CarrinhoCompra>> ObterCarrinhoPorId(int id)
        {
            try
            {
                var carrinho = await _carrinhoCompraRepository.ObterCarrinhoPorId(id);
                return Ok(carrinho);
            }
            catch (ArgumentException)
            {
                return NotFound("Carrinho não encontrado.");
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo carrinho de compra")]
        [SwaggerResponse(StatusCodes.Status201Created, "Carrinho criado com sucesso", typeof(CarrinhoCompra))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<CarrinhoCompra>> CriarNovoCarrinho([FromBody] CarrinhoCompra carrinho)
        {
            if (carrinho == null)
            {
                return BadRequest("Carrinho não pode ser nulo.");
            }

            var id = await _carrinhoCompraRepository.CriarNovoCarrinho(carrinho);
            var createdCarrinho = await _carrinhoCompraRepository.ObterCarrinhoPorId(id);
            return CreatedAtAction(nameof(ObterCarrinhoPorId), new { id = id }, createdCarrinho);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Atualiza um carrinho de compra existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho não encontrado")]
        public async Task<IActionResult> AtualizarCarrinho(int id, [FromBody] CarrinhoCompra carrinho)
        {
            if (id != carrinho.IDCarrinho)
            {
                return BadRequest("ID do carrinho não corresponde ao ID na URL.");
            }

            try
            {
                await _carrinhoCompraRepository.AtualizarCarrinho(carrinho);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:int}/habilitar")]
        [SwaggerOperation(Summary = "Habilita um carrinho de compra existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho não encontrado")]
        public async Task<IActionResult> HabilitarCarrinho(int id)
        {
            try
            {
                await _carrinhoCompraRepository.HabilitarCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:int}/desabilitar")]
        [SwaggerOperation(Summary = "Desabilita um carrinho de compra existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Carrinho desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Carrinho não encontrado")]
        public async Task<IActionResult> DesabilitarCarrinho(int id)
        {
            try
            {
                await _carrinhoCompraRepository.DesabilitarCarrinho(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
