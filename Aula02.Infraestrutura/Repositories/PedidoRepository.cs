using Aula02.Domain.Interfaces;
using Aula02.Domain.Models;
using Aula02.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Aula02.Infraestrutura.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;
        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AtualizarPedidoAsync(Pedido pPedido)
        {
            _context.Entry(pPedido).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task CriarPedidoAsync(Pedido pPedido)
        {
            _context.Pedidos.Add(pPedido);

            await _context.SaveChangesAsync();
        }

        public async Task ExcluirPedidoAsync(Pedido pPedido)
        {
            _context.Pedidos.Remove(pPedido);

            await _context.SaveChangesAsync();
        }

        public async Task<Pedido> RetornaPedidoPorIdAsync(int pId)
        {
            return await _context.Pedidos.FindAsync(pId);
        }

        public async Task<IEnumerable<Pedido>> RetornaTodosPedidosAsync()
        {
            return await _context.Pedidos.ToListAsync();
        }
    }
}
