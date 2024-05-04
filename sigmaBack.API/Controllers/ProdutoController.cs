using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de produtos")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de produtos", typeof(IEnumerable<Produto>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            var produtos = await _produtoService.ObterTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um produto por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o produto encontrado", typeof(Produto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Produto não encontrado")]
        public async Task<ActionResult<Produto>> GetById(int id)
        {
            var produto = await _produtoService.ObterProdutoPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo produto")]
        [SwaggerResponse(StatusCodes.Status201Created, "Produto criado com sucesso", typeof(Produto))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            try
            {
                await _produtoService.InserirProduto(produto);
                return CreatedAtAction(nameof(GetById), new { id = produto.IDProduto }, produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um produto existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Produto atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Produto não encontrado")]
        public async Task<IActionResult> Put(int id, Produto produto)
        {
            if (id != produto.IDProduto)
            {
                return BadRequest("ID do produto não corresponde ao ID na URL.");
            }

            try
            {
                await _produtoService.AtualizarProduto(produto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um produto existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Produto desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Produto não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _produtoService.DesabilitarProduto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um produto existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Produto habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Produto não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _produtoService.HabilitarProduto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
