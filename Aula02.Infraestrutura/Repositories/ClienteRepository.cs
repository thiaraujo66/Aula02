using Aula02.Domain.Interfaces;
using Aula02.Domain.Models;
using Aula02.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;

namespace Aula02.Infraestrutura.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task AtualizarClienteAsync(Cliente pCliente)
        {
            _context.Entry(pCliente).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task CriarClienteAsync(Cliente pCliente)
        {
            _context.Clientes.Add(pCliente);

            await _context.SaveChangesAsync();
        }

        public async Task ExcluirClienteAsync(Cliente pCliente)
        {
            _context.Clientes.Remove(pCliente);

            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> RetornaClientePorIdAsync(int pId)
        {
            return await _context.Clientes.FindAsync(pId);
        }

        public async Task<IEnumerable<Cliente>> RetornaTodosClientesAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}
