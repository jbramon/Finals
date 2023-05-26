namespace Orders.Models
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public int Quantity { get; set; }
        /// <summary>
        /// The foreign key.
        /// </summary>
        public int OrderId { get; set; }
        public float Price { get; set; }
    }
}
