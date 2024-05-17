using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritoController : ControllerBase
    {
        private readonly IFavoritoService _favoritoService;

        public FavoritoController(IFavoritoService favoritoService)
        {
            _favoritoService = favoritoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de favoritos")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de favoritos", typeof(IEnumerable<Favorito>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Favorito>>> Get()
        {
            var favoritos = await _favoritoService.ObterTodosFavoritos();
            return Ok(favoritos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um favorito por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o favorito encontrado", typeof(Favorito))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Favorito não encontrado")]
        public async Task<ActionResult<Favorito>> GetById(int id)
        {
            var favorito = await _favoritoService.ObterFavoritoPorId(id);
            if (favorito == null)
            {
                return NotFound();
            }
            return Ok(favorito);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo favorito")]
        [SwaggerResponse(StatusCodes.Status201Created, "Favorito adicionado com sucesso", typeof(Favorito))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Favorito>> Post(Favorito favorito)
        {
            try
            {
                var createdFavoritoId = await _favoritoService.AdicionarFavorito(favorito);
                var createdFavorito = await _favoritoService.ObterFavoritoPorId(createdFavoritoId);
                return CreatedAtAction(nameof(GetById), new { id = createdFavoritoId }, createdFavorito);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um favorito existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Favorito atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Favorito não encontrado")]
        public async Task<IActionResult> Put(int id, Favorito favorito)
        {
            if (id != favorito.IDFavorito)
            {
                return BadRequest("ID do favorito não corresponde ao ID na URL.");
            }

            try
            {
                await _favoritoService.AtualizarFavorito(favorito);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um favorito existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Favorito desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Favorito não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _favoritoService.DesabilitarFavorito(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um favorito existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Favorito habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Favorito não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _favoritoService.HabilitarFavorito(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
