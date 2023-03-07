using FeriadosNacionais.Domain.Models;
using FeriadosNacionais.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace FeriadosNacionais.Api.Controllers
{
    [Route("api/feriados")]
    [ApiController]
    public class FeriadosController : ControllerBase
    {
        private readonly IFeriadosService _feriadosService;

        public FeriadosController(IFeriadosService feriadosService)
        {
            _feriadosService = feriadosService;
        }

        [HttpPost]
        [Route("AtualizaBase")]
        public async Task<IActionResult> AtualizarTabelaAsync()
        {
            try
            {
                await _feriadosService.CarregarDadosFeriados();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("ObterFeriados")]
        public async Task<ActionResult> ObterTodos()
        {
            try
            {
                var feriadosList = await _feriadosService.ObterFeriadosTodos();

                return Ok(feriadosList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Incluir")]
        public async Task<ActionResult> Incluir([FromBody] FeriadosDatasModel feriadosDatasModel)
        {
            try
            {
                await _feriadosService.IncluirFeriado(feriadosDatasModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody]FeriadosDatasModel feriadosDatasModel)
        {
            try
            {
                await _feriadosService.AtualizarFeriado(feriadosDatasModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("Deletar")]
        public async Task<ActionResult> Deletar([FromBody] FeriadosDatasModel feriadosDatasModel)
        {
            try
            {
                await _feriadosService.DeletarFeriado(feriadosDatasModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
