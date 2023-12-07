using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Fin_Conta_BancariaController : Controller
    {
        private IFin_Conta_BancariaService _service;

        public Fin_Conta_BancariaController(IFin_Conta_BancariaService service)
        {
            _service = service;
        }

        [HttpGet("Lista")]
        public IActionResult Lista(int pes_codigo)
        {
            try
            {
                var obj = _service.lista(pes_codigo);
                return Ok(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("ListaSelect")]
        public IActionResult ListaSelect(int pes_codigo)
        {
            try
            {
                var obj = _service.listaSelect(pes_codigo);
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

        [HttpPost("Salvar")]
        public IActionResult Salvar([FromBody] Fin_Conta_Bancaria obj)
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
