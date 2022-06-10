using Microsoft.AspNetCore.Mvc;
using OrderingApi.Dto;
using OrderingApi.Repositories;
using System.Net;

namespace OrderingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
       private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<OrderDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrdersByUserName(string userName)
        {
            IEnumerable<OrderDTO> orders =  await _orderRepository.GetOrdersListAsync(userName);
            return Ok(orders);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] OrderDTO request)
        {
            await _orderRepository.UpdateOrder(request);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _orderRepository.DeleteOrder(id);
            return NoContent();
        }
    }
}
