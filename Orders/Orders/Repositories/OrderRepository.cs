using Customers.Contexts;
using Customers.Dto;
using Customers.Models;
using Microsoft.EntityFrameworkCore;
using Orders.Models;

namespace Customers.Repositories
{
    public class OrderRepository : IRepository<Order>

    {


        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public Order Get(int id)
        {
            return _context.Orders.Where(o => o.Id == id).Include(o =>o.Items).FirstOrDefault();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Items).ToList();
        }
        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();

        }


        public void Update(Order order, Order updatedorder)
        {
            order.orderdate = updatedorder.orderdate;
            order.orderprocessed = updatedorder.orderprocessed;
            order.Items = updatedorder.Items;
            _context.SaveChanges();

        }
    }
}