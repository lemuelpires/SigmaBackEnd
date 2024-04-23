using Microsoft.AspNetCore.Mvc;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
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
        public async Task<IActionResult> CriarUsuario(Usuario usuario)
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
        public async Task<IActionResult> AtualizarUsuario(int id, Usuario usuario)
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

