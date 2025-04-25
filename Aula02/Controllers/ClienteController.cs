using Aula02.Domain.Interfaces;
using Aula02.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) 
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> RetornaTodosClientes() 
        {
            try
            {
                IEnumerable<Cliente> clientes = await _clienteService.RetornaTodosClientesAsync();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{pId}")]
        public async Task<ActionResult<Cliente>> RetornaCliente(int pId) 
        {
            try
            {
                Cliente cliente = await _clienteService.RetornaClientePorIdAsync(pId);

                if (cliente == null)
                    return NotFound();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> CriarCliente([FromBody] Cliente pCliente) 
        {
            try
            {
                Cliente novoCliente = await _clienteService.CriarCliente(pCliente);

                return CreatedAtAction(nameof(RetornaCliente), new { id = novoCliente.Id }, novoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{pId}")]
        public async Task<IActionResult> AtualizaCliente(int pId, [FromBody] Cliente pCliente) 
        {
            try
            {
                if (pId != pCliente.Id)
                    return BadRequest();

                bool atualizado = await _clienteService.AtualizarCliente(pCliente);

                if (!atualizado)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{pId}")]
        public async Task<IActionResult> Delete(int pId) 
        {
            try
            {
                bool excluido = await _clienteService.ExcluirCliente(pId);

                if (!excluido)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
