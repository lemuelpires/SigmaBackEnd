using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
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
        [SwaggerOperation(Summary = "Obtém a lista de endereços")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de endereços", typeof(IEnumerable<Endereco>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Endereco>>> Get()
        {
            var enderecos = await _enderecoService.ObterTodosEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um endereço por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o endereço encontrado", typeof(Endereco))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        public async Task<ActionResult<Endereco>> GetById(int id)
        {
            var endereco = await _enderecoService.ObterEnderecoPorId(id);
            if (endereco == null)
            {
                return NotFound();
            }
            return Ok(endereco);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo endereço")]
        [SwaggerResponse(StatusCodes.Status201Created, "Endereço criado com sucesso", typeof(Endereco))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<Endereco>> Post(Endereco endereco)
        {
            try
            {
                var createdEnderecoId = await _enderecoService.CriarNovoEndereco(endereco);
                var createdEndereco = await _enderecoService.ObterEnderecoPorId(createdEnderecoId);
                return CreatedAtAction(nameof(GetById), new { id = createdEnderecoId }, createdEndereco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um endereço existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Endereço atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        public async Task<IActionResult> Put(int id, Endereco endereco)
        {
            if (id != endereco.IDEndereco)
            {
                return BadRequest("ID do endereço não corresponde ao ID na URL.");
            }

            try
            {
                await _enderecoService.AtualizarEndereco(endereco);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um endereço existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Endereço desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _enderecoService.DesabilitarEndereco(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um endereço existente")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Endereço habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Endereço não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _enderecoService.HabilitarEndereco(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
