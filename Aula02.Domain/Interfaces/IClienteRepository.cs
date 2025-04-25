using Aula02.Domain.Models;

namespace Aula02.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> RetornaClientePorIdAsync(int pId);
        Task<IEnumerable<Cliente>> RetornaTodosClientesAsync();
        Task CriarClienteAsync(Cliente pCliente);
        Task AtualizarClienteAsync(Cliente pCliente);
        Task ExcluirClienteAsync(Cliente pCliente);
    }
}
