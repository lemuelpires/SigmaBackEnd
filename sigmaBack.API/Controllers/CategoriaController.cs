using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de categorias")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de categorias", typeof(IEnumerable<Categoria>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Categoria>>> Get()
        {
            var categorias = await _categoriaService.ObterTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma categoria por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a categoria encontrada", typeof(Categoria))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Categoria não encontrada")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            var categoria = await _categoriaService.ObterCategoriaPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova categoria")]
        [SwaggerResponse(StatusCodes.Status201Created, "Categoria criada com sucesso", typeof(Categoria))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try
            {
                var createdCategoriaId = await _categoriaService.CriarNovaCategoria(categoria);
                var createdCategoria = await _categoriaService.ObterCategoriaPorId(createdCategoriaId);
                return CreatedAtAction(nameof(GetById), new { id = createdCategoriaId }, createdCategoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma categoria existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Categoria atualizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Categoria não encontrada")]
        public async Task<IActionResult> Put(int id, Categoria categoria)
        {
            if (id != categoria.IDCategoria)
            {
                return BadRequest("ID da categoria não corresponde ao ID na URL.");
            }

            try
            {
                await _categoriaService.AtualizarCategoria(categoria);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita uma categoria existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Categoria desabilitada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Categoria não encontrada")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _categoriaService.DesabilitarCategoria(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita uma categoria existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Categoria habilitada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Categoria não encontrada")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _categoriaService.HabilitarCategoria(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
