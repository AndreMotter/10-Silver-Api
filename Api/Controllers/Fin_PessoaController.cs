using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Fin_PessoaController : Controller
    {
        private IFin_PessoaService _service;

        public Fin_PessoaController(IFin_PessoaService service)
        {
            _service = service;
        }

        [HttpGet("Lista")]
        public IActionResult Lista(string pessoa, string cpf)
        {
            try
            {
                var obj = _service.lista(pessoa, cpf);
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
                var obj = _service.buscaPorId(id);
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
                _service.ativar(id);
                return Ok(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public IActionResult Salvar([FromBody] Fin_Pessoa obj)
        {
            try
            {
                _service.salvar(obj);
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
                _service.remover(id);
                return Ok(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
