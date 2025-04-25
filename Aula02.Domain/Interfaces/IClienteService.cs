using Aula02.Domain.Models;

namespace Aula02.Domain.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> RetornaClientePorIdAsync(int pId);
        Task<IEnumerable<Cliente>> RetornaTodosClientesAsync();
        Task<Cliente> CriarCliente(Cliente pCliente);
        Task<bool> AtualizarCliente(Cliente pCliente);
        Task<bool> ExcluirCliente(int pId);
    }
}
