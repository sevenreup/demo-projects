using OrderingApi.Dto;

namespace OrderingApi.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDTO>> GetOrdersListAsync(string userName);
        Task UpdateOrder(OrderDTO request);
        Task DeleteOrder(int id);
    }
}
