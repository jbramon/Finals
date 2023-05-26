using Customers.Dto;

namespace Customers.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();

        OrderDto GetOrderById(int id);

        void AddOrder(CreateOrderDto order);

        OrderDto UpdateOrder(OrderDto order);

        void DeleteOrder(int id);
    }
}
