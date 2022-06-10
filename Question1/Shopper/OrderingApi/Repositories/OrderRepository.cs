using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderingApi.Data;
using OrderingApi.Dto;
using OrderingApi.Entities;

namespace OrderingApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        private readonly IMapper _mapper;
        public OrderRepository(OrderContext dbContext, IMapper mapper) 
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if(order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersListAsync(string userName)
        {
            var list = await _context.Orders.Where(x => x.UserName.Equals(userName)).ToListAsync();
            return list.Select(x => _mapper.Map<OrderDTO>(x));
        }

        public async Task UpdateOrder(OrderDTO request)
        {
            _context.Orders.Update(_mapper.Map<Order>(request));
            await _context.SaveChangesAsync();
        }
    }
}
