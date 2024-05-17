using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioService _anuncioService;

        public AnuncioController(IAnuncioService anuncioService)
        {
            _anuncioService = anuncioService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de anúncios")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retorna a lista de anúncios", typeof(IEnumerable<Anuncio>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Anuncio>>> Get()
        {
            var anuncios = await _anuncioService.ObterTodosAnuncios();
            return Ok(anuncios);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um anúncio por ID")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retorna o anúncio encontrado", typeof(Anuncio))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Anúncio não encontrado")]
        public async Task<ActionResult<Anuncio>> GetById(int id)
        {
            try
            {
                var anuncio = await _anuncioService.ObterAnuncioPorId(id);
                return Ok(anuncio);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo anúncio")]
        [SwaggerResponse((int)HttpStatusCode.Created, "Anúncio criado com sucesso", typeof(Anuncio))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Anuncio>> Post(Anuncio anuncio)
        {
            try
            {
                var createdAnuncioId = await _anuncioService.CriarAnuncio(anuncio);
                var createdAnuncio = await _anuncioService.ObterAnuncioPorId(createdAnuncioId);
                return CreatedAtAction(nameof(GetById), new { id = createdAnuncioId }, createdAnuncio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um anúncio existente")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Anúncio atualizado com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Anúncio não encontrado")]
        public async Task<IActionResult> Put(int id, Anuncio anuncio)
        {
            if (id != anuncio.IDAnuncio)
            {
                return BadRequest("ID do anúncio não corresponde ao ID na URL.");
            }

            try
            {
                await _anuncioService.AtualizarAnuncio(id, anuncio);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um anúncio existente")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Anúncio habilitado com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Anúncio não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _anuncioService.HabilitarAnuncio(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um anúncio existente")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Anúncio desabilitado com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Anúncio não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _anuncioService.DesabilitarAnuncio(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
