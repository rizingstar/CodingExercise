using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Model;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderRepository _orderRepository;
        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            return Ok(_orderRepository.All);
        }

        // POST: api/Orders
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Order> PostOrder(Order Order)
        {
            _orderRepository.Insert(Order);

            return CreatedAtAction(nameof(GetOrder), new { id = Order.Id }, Order);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Order> GetOrder(int id)
        {
            var Order = _orderRepository.Find(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Ok(Order);
        }
    }
}
