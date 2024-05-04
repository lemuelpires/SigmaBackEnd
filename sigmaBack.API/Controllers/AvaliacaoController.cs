using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;

        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de avaliações")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de avaliações", typeof(IEnumerable<Avaliacao>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> Get()
        {
            var avaliacoes = await _avaliacaoService.GetAllAvaliacoesAsync();
            return Ok(avaliacoes);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma avaliação por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a avaliação encontrada", typeof(Avaliacao))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Avaliação não encontrada")]
        public async Task<ActionResult<Avaliacao>> GetById(int id)
        {
            var avaliacao = await _avaliacaoService.GetAvaliacaoByIdAsync(id);
            if (avaliacao == null)
            {
                return NotFound();
            }
            return Ok(avaliacao);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova avaliação")]
        [SwaggerResponse(StatusCodes.Status201Created, "Avaliação criada com sucesso", typeof(Avaliacao))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Avaliacao>> Post(Avaliacao avaliacao)
        {
            try
            {
                var createdAvaliacao = await _avaliacaoService.CreateAvaliacaoAsync(avaliacao);
                return CreatedAtAction(nameof(GetById), new { id = createdAvaliacao.IDAvaliacao }, createdAvaliacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma avaliação existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Avaliação atualizada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Avaliação não encontrada")]
        public async Task<IActionResult> Put(int id, Avaliacao avaliacao)
        {
            if (id != avaliacao.IDAvaliacao)
            {
                return BadRequest("ID da avaliação não corresponde ao ID na URL.");
            }

            try
            {
                await _avaliacaoService.UpdateAvaliacaoAsync(avaliacao);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita uma avaliação existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Avaliação desabilitada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Avaliação não encontrada")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _avaliacaoService.DisabilitarAvaliacaoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita uma avaliação existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Avaliação habilitada com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Avaliação não encontrada")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _avaliacaoService.HabilitarAvaliacaoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
