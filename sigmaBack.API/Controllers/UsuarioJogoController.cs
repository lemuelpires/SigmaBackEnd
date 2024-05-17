using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using sigmaBack.Application.Services;
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
    public class UsuarioJogoController : ControllerBase
    {
        private readonly IUsuarioJogoService _usuarioJogoService;

        public UsuarioJogoController(IUsuarioJogoService usuarioJogoService)
        {
            _usuarioJogoService = usuarioJogoService ?? throw new ArgumentNullException(nameof(usuarioJogoService));
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Obtém a lista de usuários de jogos")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retorna a lista de usuários de jogos", typeof(IEnumerable<UsuarioJogo>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Erro interno do servidor")]
        public async Task<ActionResult<IEnumerable<UsuarioJogo>>> Get()
        {
            var usuariosJogo = await _usuarioJogoService.ObterTodosUsuarioJogo();
            return Ok(usuariosJogo);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um usuário de jogo por ID")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Retorna o usuário de jogo encontrado", typeof(UsuarioJogo))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Usuário de jogo não encontrado")]
        public async Task<ActionResult<UsuarioJogo>> GetById(int id)
        {
            var usuarioJogo = await _usuarioJogoService.ObterUsuarioJogoPorId(id);
            if (usuarioJogo == null)
            {
                return NotFound();
            }
            return Ok(usuarioJogo);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo usuário de jogo")]
        [SwaggerResponse((int)HttpStatusCode.Created, "Usuário de jogo criado com sucesso", typeof(UsuarioJogo))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        public async Task<ActionResult<UsuarioJogo>> Post(UsuarioJogo usuarioJogo)
        {
            try
            {
                var idUsuarioJogo = await _usuarioJogoService.AdicionarUsuarioJogo(usuarioJogo);
                return CreatedAtAction(nameof(GetById), new { id = idUsuarioJogo }, usuarioJogo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um usuário de jogo existente")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Usuário de jogo atualizado com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Usuário de jogo não encontrado")]
        public async Task<IActionResult> Put(int id, UsuarioJogo usuarioJogo)
        {
            if (id != usuarioJogo.IDAssociacao)
            {
                return BadRequest("ID do usuário de jogo não corresponde ao ID na URL.");
            }

            try
            {
                await _usuarioJogoService.AtualizarUsuarioJogo(usuarioJogo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/disable")]
        [SwaggerOperation(Summary = "Desabilita um usuário de jogo existente")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Usuário de jogo desabilitado com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Usuário de jogo não encontrado")]
        public async Task<IActionResult> Disable(int id)
        {
            try
            {
                await _usuarioJogoService.DesabilitarUsuarioJogo(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}/enable")]
        [SwaggerOperation(Summary = "Habilita um usuário de jogo existente")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Usuário de jogo habilitado com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição inválida")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Usuário de jogo não encontrado")]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await _usuarioJogoService.HabilitarUsuarioJogo(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
