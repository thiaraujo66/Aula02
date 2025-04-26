using Aula02.Domain.Models;

namespace Aula02.Domain.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> RetornaPedidoPorIdAsync(int pId);
        Task<IEnumerable<Pedido>> RetornaTodosPedidosAsync();
        Task<Pedido> CriarPedido(Pedido pPedido);
        Task<bool> AtualizarPedido(Pedido pPedido);
        Task<bool> ExcluirPedido(int pId);
    }
}
