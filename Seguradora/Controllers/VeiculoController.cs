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
    public class VeiculoController : ControllerBase
    {

        private readonly ILogger<VeiculoController> _logger;

        private readonly IVeiculoService _VeiculoService;

        public VeiculoController(ILogger<VeiculoController> logger, IVeiculoService VeiculoService)
        {
            _logger = logger;
            _VeiculoService = VeiculoService;
        }

        [HttpGet("ObterVeiculoPorId/{IdVeiculo}")]
        public async Task<IActionResult> ObterVeiculoPorId(int IdVeiculo)
        {
            try
            {
                Veiculo retorno = await _VeiculoService.ObterPorId(IdVeiculo);

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

        [HttpPost("AdicionarVeiculo")]
        public async Task<IActionResult> AdicionarVeiculo([FromBody] Veiculo Veiculo)
        {
            try
            {
                Veiculo retorno = await _VeiculoService.AdicionarVeiculo(Veiculo);

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


        [HttpDelete("ExcluirVeiculo/{idVeiculo}")]
        public async Task<IActionResult> ExcluirVeiculo(int idVeiculo)
        {
            try
            {
                bool VeiculoExcluido = await _VeiculoService.ExcluirVeiculo(idVeiculo);

                if (VeiculoExcluido)
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

        [HttpPut("AtualizarVeiculo")]
        public async Task<IActionResult> AtualizarVeiculo(Veiculo veiculo)
        {
            try
            {
                Veiculo VeiculoAtualizado = await _VeiculoService.AtualizarVeiculo(veiculo);

                if (VeiculoAtualizado != null)
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
