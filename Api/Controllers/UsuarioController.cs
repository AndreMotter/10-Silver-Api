using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet("ListaUsuarios")]
        public IActionResult ListaUsuarios(string usuario, int status)
        {
            try
            {
                var obj = _service.listaUsuarios(usuario, status);
                return Ok(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("BuscaPorId")]
        public IActionResult BuscaPorId(int id)
        {
            try
            {
                var obj = _service.BuscaPorId(id);
                return Ok(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("Ativar")]
        public IActionResult Ativar(int id)
        {
            try
            {
                _service.Ativar(id);
                return Ok(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public IActionResult Salvar([FromBody] Usuario obj)
        {
            try
            {
                _service.Salvar(obj);
                return Ok(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpDelete("Remover")]
        public IActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return Ok(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
