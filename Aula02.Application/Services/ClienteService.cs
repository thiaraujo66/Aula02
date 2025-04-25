using Aula02.Domain.Interfaces;
using Aula02.Domain.Models;

namespace Aula02.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> AtualizarCliente(Cliente pCliente)
        {
            try
            {
                Cliente cliente = await _clienteRepository.RetornaClientePorIdAsync(pCliente.Id);

                if (cliente == null)
                    return false;

                cliente.Nome = pCliente.Nome;
                cliente.Email = pCliente.Email;

                await _clienteRepository.AtualizarClienteAsync(cliente);
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public async Task<Cliente> CriarCliente(Cliente pCliente)
        {
            try
            {
                await _clienteRepository.CriarClienteAsync(pCliente);

                return pCliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ExcluirCliente(int pId)
        {
            try
            {
                Cliente cliente = await _clienteRepository.RetornaClientePorIdAsync(pId);

                if (cliente == null)
                    return false;

                await _clienteRepository.ExcluirClienteAsync(cliente);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> RetornaClientePorIdAsync(int pId)
        {
            try
            {
                Cliente cliente = await _clienteRepository.RetornaClientePorIdAsync(pId);
                if (cliente == null)
                    return null;

                return cliente;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Cliente>> RetornaTodosClientesAsync()
        {
            try
            {
                IEnumerable<Cliente> clientes = await _clienteRepository.RetornaTodosClientesAsync();

                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
