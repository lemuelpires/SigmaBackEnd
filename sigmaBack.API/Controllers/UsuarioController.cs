using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todos os usuários.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de todos os usuários.", typeof(IEnumerable<Usuario>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.ObterTodosUsuarios();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter usuários: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário por ID.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Usuário encontrado.", typeof(Usuario))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> ObterUsuarioPorId(int id)
        {
            try
            {
                var usuario = await _usuarioService.ObterUsuarioPorId(id);
                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter usuário: {ex.Message}");
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo usuário.")]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário criado com sucesso.", typeof(Usuario))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro de solicitação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> CriarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var idUsuario = await _usuarioService.RegistrarNovoUsuario(usuario);
                return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = idUsuario }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar usuário: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um usuário.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Usuário atualizado com sucesso.")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Erro de solicitação.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> AtualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                usuario.IDUsuario = id; // Definindo o ID do usuário no objeto
                await _usuarioService.AtualizarPerfilUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar usuário: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um usuário.")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Usuário removido com sucesso.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor.")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            try
            {
                await _usuarioService.RemoverUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao remover usuário: {ex.Message}");
            }
        }
    }
}
//