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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosEnderecos()
        {
            try
            {
                var enderecos = await _enderecoService.ObterTodosEnderecos();
                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter endereços: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEnderecoPorId(int id)
        {
            try
            {
                var endereco = await _enderecoService.ObterEnderecoPorId(id);
                if (endereco == null)
                    return NotFound();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter endereço: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarNovoEndereco(Endereco endereco)
        {
            try
            {
                var idEndereco = await _enderecoService.CriarNovoEndereco(endereco);
                return CreatedAtAction(nameof(ObterEnderecoPorId), new { id = idEndereco }, endereco);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar endereço: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEndereco(int id, Endereco endereco)
        {
            try
            {
                await _enderecoService.AtualizarEndereco(endereco);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar endereço: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverEndereco(int id)
        {
            try
            {
                await _enderecoService.RemoverEndereco(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover endereço: {ex.Message}");
            }
        }
    }
}
