using Aula02.Domain.Models;

namespace Aula02.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> RetornaPedidoPorIdAsync(int pId);
        Task<IEnumerable<Pedido>> RetornaTodosPedidosAsync();
        Task CriarPedidoAsync(Pedido pPedido);
        Task AtualizarPedidoAsync(Pedido pPedido);
        Task ExcluirPedidoAsync(Pedido pPedido);
    }
}
