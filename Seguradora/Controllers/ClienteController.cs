using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seguradora.Entities;
using Seguradora.Intefaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Seguradora.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;

        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger;
            _clienteService = clienteService;
        }

        [HttpGet("ObterClientePorId/{IdCliente}")]
        public async Task<IActionResult> ObterClientePorId(int IdCliente)
        {
            try
            {
                Cliente retorno = await _clienteService.ObterPorId(IdCliente);

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

        [HttpGet("ObterTodosClientes")]
        public async Task<IActionResult> ObterTodosClientes()
        {
            try
            {
                var retorno = await _clienteService.ObterTodosClientes();

                if (retorno != null && retorno.Any())
                {
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest("Não existem clientes cadastrados!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("AdicionarCliente")]
        public async Task<IActionResult> AdicionarCliente([FromBody] Cliente cliente)
        {
            try
            {
                Cliente retorno = await _clienteService.AdicionarCliente(cliente);

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

        [HttpDelete("ExcluirCliente/{idCLiente}")]
        public async Task<IActionResult> ExcluirCliente(int idCLiente)
        {
            try
            {
                bool clienteExcluido = await _clienteService.ExcluirCliente(idCLiente);

                if (clienteExcluido)
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

        [HttpPut("AtualizarCliente")]
        public async Task<IActionResult> AtualizarCliente(Cliente cliente)
        {
            try
            {
                Cliente clienteAtualizado = await _clienteService.AtualizarCliente(cliente);

                if (clienteAtualizado != null)
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

        [HttpPost("Login")]
        public async Task<IActionResult> LogarCliente(Usuario usuario)
        {
            try
            {
                bool clienteLogado = await _clienteService.LogarUsuario(usuario);

                if (clienteLogado)
                {
                    return Ok("Cliente logado!");
                }
                else
                {
                    return BadRequest("Cliente não possui cadastro!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"ERROR - Mensagem - {ex.Message}");
            }
        }
    }
}
