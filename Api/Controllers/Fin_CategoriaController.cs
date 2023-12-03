using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Fin_categoriaController : Controller
    {
        private IFin_categoriaService _service;

        public Fin_categoriaController(IFin_categoriaService service)
        {
            _service = service;
        }

        [HttpGet("Lista")]
        public IActionResult Lista(string cat_sigla, int cat_tipo, int first, int rows)
        {
            try
            {
                var obj = _service.lista(cat_sigla, cat_tipo, first, rows);
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
        public IActionResult Salvar([FromBody] Fin_categoria obj)
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
