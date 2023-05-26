using Orders.Models;

namespace Customers.Dto
{
    public class CreateOrderDto
    {
        public DateTime orderdate { get; set; }
        public bool orderprocessed { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
