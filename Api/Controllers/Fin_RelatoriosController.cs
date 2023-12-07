using App.Domain.DTO;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Fin_RelatoriosController : Controller
    {
        private IFin_RelatoriosService _service;

        public Fin_RelatoriosController(IFin_RelatoriosService service)
        {
            _service = service;
        }

        [HttpGet("ImprimirMovimentos")]
        public IActionResult ImprimirMovimentos(int pes_codigo, int mov_tipo, int cat_codigo, DateTime? data_inicial, DateTime? data_final)
        {
            try
            {
                var obj = _service.imprimirMovimentos(pes_codigo, mov_tipo, cat_codigo, data_inicial, data_final);
                return Ok(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)

            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
