using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Interfaces;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ActionResult<IEnumerable<Avaliacao>>> Get()
        {
            var avaliacoes = await _avaliacaoService.GetAllAvaliacoesAsync();
            return Ok(avaliacoes);
        }

        [HttpGet("{id}")]
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _avaliacaoService.DeleteAvaliacaoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
