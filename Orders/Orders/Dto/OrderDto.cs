using Customers.Models;
using Orders.Dto;
using Orders.Models;

namespace Customers.Dto
{
    public class OrderDto
    {
       public int Id { get; set; }
       public DateTime orderdate { get; set; } 
       public bool orderprocessed { get; set; }

       public ICollection<ItemDto> Items { get; set; }
    }
}
