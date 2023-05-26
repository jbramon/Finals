using Orders.Models;

namespace Customers.Models
{
    //Principal entity
    public class Order
    {
        public int Id { get; set; }
        public DateTime orderdate { get; set; } 
        public bool orderprocessed { get; set; } 
        /// <summary>
        /// One to many. A list of Items
        /// </summary>
        public IEnumerable<Item> Items { get; set; }
    }
}
