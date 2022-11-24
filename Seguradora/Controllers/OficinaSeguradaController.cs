using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Threading.Tasks;

namespace Seguradora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OficinaSeguradaController : ControllerBase
    {

        private readonly ILogger<OficinaSeguradaController> _logger;

        private readonly IOficinaSeguradaService _OficinaSeguradaService;

        public OficinaSeguradaController(ILogger<OficinaSeguradaController> logger, IOficinaSeguradaService OficinaSeguradaService)
        {
            _logger = logger;
            _OficinaSeguradaService = OficinaSeguradaService;
        }

        [HttpGet("ObterOficinaSeguradaPorId/{IdOficinaSegurada}")]
        public async Task<IActionResult> ObterOficinaSeguradaPorId(int IdOficinaSegurada)
        {
            try
            {
                OficinaSegurada retorno = await _OficinaSeguradaService.ObterPorId(IdOficinaSegurada);

                if (retorno != null)
                {
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest("Object was Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AdicionarOficinaSegurada")]
        public async Task<IActionResult> AdicionarOficinaSegurada([FromBody] OficinaSegurada OficinaSegurada)
        {
            try
            {
                OficinaSegurada retorno = await _OficinaSeguradaService.AdicionarOficinaSegurada(OficinaSegurada);

                if (retorno != null)
                {
                    return StatusCode(201);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("ExcluirOficinaSegurada/{idOficinaSegurada}")]
        public async Task<IActionResult> ExcluirOficinaSegurada(int idOficinaSegurada)
        {
            try
            {
                bool OficinaSeguradaExcluido = await _OficinaSeguradaService.ExcluirOficinaSegurada(idOficinaSegurada);

                if (OficinaSeguradaExcluido)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Object was Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("AtualizarOficinaSegurada")]
        public async Task<IActionResult> AtualizarOficinaSegurada(OficinaSegurada idOficinaSegurada)
        {
            try
            {
                OficinaSegurada OficinaSeguradaAtualizado = await _OficinaSeguradaService.AtualizarOficinaSegurada(idOficinaSegurada);

                if (OficinaSeguradaAtualizado != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("Object was Not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
