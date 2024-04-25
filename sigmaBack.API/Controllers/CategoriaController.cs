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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todas as categorias.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todas as categorias.", typeof(IEnumerable<Categoria>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterTodasCategorias()
        {
            try
            {
                var categorias = await _categoriaService.ObterTodasCategorias();
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter categorias: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma categoria por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Categoria encontrada.", typeof(Categoria))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Categoria não encontrada.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterCategoriaPorId(int id)
        {
            try
            {
                var categoria = await _categoriaService.ObterCategoriaPorId(id);
                if (categoria == null)
                    return NotFound();

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter categoria: {ex.Message}");
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova categoria.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Categoria criada com sucesso.", typeof(Categoria))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> CriarNovaCategoria([FromBody] Categoria categoria)
        {
            try
            {
                var idCategoria = await _categoriaService.CriarNovaCategoria(categoria);
                return CreatedAtAction(nameof(ObterCategoriaPorId), new { id = idCategoria }, categoria);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar categoria: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma categoria existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Categoria atualizada com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AtualizarCategoria(int id, [FromBody] Categoria categoria)
        {
            try
            {
                await _categoriaService.AtualizarCategoria(categoria);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar categoria: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma categoria existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Categoria removida com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> RemoverCategoria(int id)
        {
            try
            {
                await _categoriaService.RemoverCategoria(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover categoria: {ex.Message}");
            }
        }
    }
}
//