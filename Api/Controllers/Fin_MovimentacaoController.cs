using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Fin_MovimentacaoController : Controller
    {
        private IFin_MovimentacaoService _service;

        public Fin_MovimentacaoController(IFin_MovimentacaoService service)
        {
            _service = service;
        }

        [HttpGet("Lista")]
        public IActionResult Lista(int pes_codigo, int mov_tipo, int cat_codigo)
        {
            try
            {
                var obj = _service.lista(pes_codigo, mov_tipo, cat_codigo);
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

        [HttpGet("ResumoMensal")]
        public IActionResult ResumoMensal(int pes_codigo, DateTime? mes_ano)
        {
            try
            {
                var obj = _service.resumoMensal(pes_codigo, mes_ano);
                return Ok(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("ResumoAnual")]
        public IActionResult ResumoAnual(int pes_codigo, int ano)
        {
            try
            {
                var obj = _service.resumoAnual(pes_codigo, ano);
                return Ok(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public IActionResult Salvar([FromBody] Fin_Movimentacao obj)
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
