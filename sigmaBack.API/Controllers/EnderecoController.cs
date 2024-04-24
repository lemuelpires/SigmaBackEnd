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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os endereços.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os endereços.", typeof(IEnumerable<Endereco>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
        [SwaggerOperation(Summary = "Obtém um endereço por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Endereço encontrado.", typeof(Endereco))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
        [SwaggerOperation(Summary = "Cria um novo endereço.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Endereço criado com sucesso.", typeof(Endereco))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> CriarNovoEndereco([FromBody] Endereco endereco)
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
        [SwaggerOperation(Summary = "Atualiza um endereço existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Endereço atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AtualizarEndereco(int id, [FromBody] Endereco endereco)
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
        [SwaggerOperation(Summary = "Remove um endereço existente.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Endereço removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
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
