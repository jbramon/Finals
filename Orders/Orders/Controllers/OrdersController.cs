using Customers.Dto;
using Customers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            if (orders.Any())
                return Ok(orders);
            else
                return NoContent();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var desiredOrder = _orderService.GetOrderById(id);

            if (desiredOrder != null)
                return Ok(desiredOrder);
            else
                return NotFound();
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Create([FromBody] CreateOrderDto order)
        {
            if (order == null)
                return BadRequest();


            _orderService.AddOrder(order);
            
            

            return Ok(order);




        }
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromBody] Dto.OrderDto order)
        {
            if (order == null)
                return BadRequest();

            var updatedOrCreatedOrder = _orderService.UpdateOrder(order);

            return Ok(updatedOrCreatedOrder);
            return Ok();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _orderService.DeleteOrder(id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }
    }
}
