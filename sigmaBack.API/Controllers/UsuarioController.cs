using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace sigmaBack.Application.Controllers
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
        [SwaggerOperation(Summary = "Obtém a lista de usuários")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna a lista de usuários", typeof(IEnumerable<Usuario>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var usuarios = await _usuarioService.ObterTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário por ID")]
        [SwaggerResponse(StatusCodes.Status200OK, "Retorna o usuário encontrado", typeof(Usuario))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        public async Task<ActionResult<Usuario>> GetById(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Registra um novo usuário")]
        [SwaggerResponse(StatusCodes.Status201Created, "Usuário registrado com sucesso", typeof(int))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        public async Task<ActionResult<int>> Post(Usuario usuario)
        {
            try
            {
                var userId = await _usuarioService.RegistrarNovoUsuario(usuario);
                return CreatedAtAction(nameof(GetById), new { id = userId }, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza o perfil de um usuário")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Perfil de usuário atualizado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            if (id != usuario.IDUsuario)
            {
                return BadRequest("ID do usuário não corresponde ao ID na URL.");
            }

            try
            {
                await _usuarioService.AtualizarPerfilUsuario(usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um usuário")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Usuário desabilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _usuarioService.DesabilitarUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um usuário")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Usuário habilitado com sucesso")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Requisição inválida")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Usuário não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _usuarioService.HabilitarUsuario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
