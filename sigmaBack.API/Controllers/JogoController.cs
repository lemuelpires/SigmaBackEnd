using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogoController(IJogoService jogoService)
        {
            _jogoService = jogoService ?? throw new ArgumentNullException(nameof(jogoService));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de jogos")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de jogos", typeof(IEnumerable<Jogo>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Jogo>>> Get()
        {
            var jogos = await _jogoService.ObterTodosJogos();
            return Ok(jogos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um jogo por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o jogo encontrado", typeof(Jogo))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Jogo não encontrado")]
        public async Task<ActionResult<Jogo>> GetById(int id)
        {
            var jogo = await _jogoService.ObterJogoPorId(id);
            if (jogo == null)
            {
                return NotFound();
            }
            return Ok(jogo);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo jogo")]
        [SwaggerResponse(StatusCodes.Status201Created, "Jogo criado com sucesso", typeof(Jogo))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Jogo>> Post(Jogo jogo)
        {
            try
            {
                await _jogoService.InserirJogo(jogo);
                return CreatedAtAction(nameof(GetById), new { id = jogo.IDJogo }, jogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um jogo existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Jogo atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Jogo não encontrado")]
        public async Task<IActionResult> Put(int id, Jogo jogo)
        {
            if (id != jogo.IDJogo)
            {
                return BadRequest("ID do jogo não corresponde ao ID na URL.");
            }

            try
            {
                await _jogoService.AtualizarJogo(jogo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um jogo existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Jogo desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Jogo não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _jogoService.DesabilitarJogo(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um jogo existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Jogo habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Jogo não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _jogoService.HabilitarJogo(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/atualizarImagem")]
        [SwaggerOperation(Summary = "Atualiza a referência da imagem de um jogo")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Imagem atualizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Jogo não encontrado")]
        public async Task<IActionResult> AtualizarImagem(int id, [FromBody] AtualizarImagemJogo request)
        {
            if (id != request.IdJogo)
            {
                return BadRequest("ID do jogo não corresponde ao ID na URL.");
            }

            if (request.ReferenciaImagemJogo == null)
            {
                return BadRequest("A referência da imagem do jogo não pode ser nula.");
            }

            try
            {
                await _jogoService.AtualizarReferenciaImagem(id, request.ReferenciaImagemJogo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
