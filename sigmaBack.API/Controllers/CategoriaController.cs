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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
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
        public async Task<IActionResult> CriarNovaCategoria(Categoria categoria)
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
        public async Task<IActionResult> AtualizarCategoria(int id, Categoria categoria)
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
