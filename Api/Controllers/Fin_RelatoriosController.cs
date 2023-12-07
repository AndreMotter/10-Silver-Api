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
        public IActionResult ImprimirMovimentos(int pes_codigo)
        {
            try
            {
                var obj = _service.imprimirMovimentos(pes_codigo);
                return Ok(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)

            {
                return BadRequest(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
