using Aula02.Domain.Interfaces;
using Aula02.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> RetornaTodosPedidos()
        {
            try
            {
                IEnumerable<Pedido> pedidos = await _pedidoService.RetornaTodosPedidosAsync();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{pId}")]
        public async Task<ActionResult<Pedido>> RetornaPedido(int pId)
        {
            try
            {
                Pedido pedido = await _pedidoService.RetornaPedidoPorIdAsync(pId);

                if (pedido == null)
                    return NotFound();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CriarPedido([FromBody] Pedido pPedido)
        {
            try
            {
                Pedido novoPedido = await _pedidoService.CriarPedido(pPedido);

                return CreatedAtAction(nameof(RetornaPedido), new { pId = novoPedido.Id }, novoPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{pId}")]
        public async Task<IActionResult> AtualizaPedido(int pId, [FromBody] Pedido pPedido)
        {
            try
            {
                if (pId != pPedido.Id)
                    return BadRequest();

                bool atualizado = await _pedidoService.AtualizarPedido(pPedido);

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
                bool excluido = await _pedidoService.ExcluirPedido(pId);

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
