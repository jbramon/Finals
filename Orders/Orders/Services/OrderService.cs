using Customers.Dto;
using Customers.Models;
using Customers.Repositories;
using Customers.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orders.Dto;
using Orders.Models;


namespace Orders.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(CreateOrderDto orderDto)
        {
            _orderRepository.Add(new Order
            {
                orderdate = orderDto.orderdate,
                orderprocessed = orderDto.orderprocessed,
                Items = orderDto.Items.Select(i => new Item
                {
                    Quantity = i.Quantity,
                    Name = i.Name,
                    Price = i.Price
                }).ToList()
            });
        }

        public OrderDto GetOrderById(int id)
        {
            var o = _orderRepository.Get(id);
            return new OrderDto
            {
                Id = o.Id,
                orderdate = o.orderdate,
                orderprocessed = o.orderprocessed,
                Items = o.Items.Select(itemModel => new ItemDto
                {
                    Id = itemModel.Id,
                    Quantity = itemModel.Quantity,
                    Name = itemModel.Name,
                    Price = itemModel.Price
                }).ToList()
            };
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var orders = _orderRepository.GetAll();
            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                orderdate = o.orderdate,
                orderprocessed = o.orderprocessed,
                Items = o.Items.Select(itemModel => new ItemDto
                {
                    Id = itemModel.Id,
                    Quantity = itemModel.Quantity,
                    Name = itemModel.Name,
                    Price = itemModel.Price
                }).ToList()
            });
        }

        public void DeleteOrder(int id)
        {
            var desiredOrder = _orderRepository.Get(id);

            if (desiredOrder == null)
                throw new Exception($"No order with id {id} exists.");

            _orderRepository.Delete(desiredOrder);
        }

        public OrderDto UpdateOrder(OrderDto orderDto)
        {
            var desiredOrder = _orderRepository.Get(orderDto.Id);

            //var items = orderDto.Items.Select(item => _itemRepository.Get(id)).ToList();

            if (desiredOrder == null)
            {
                _orderRepository.Add(new Order
                {
                    orderdate = orderDto.orderdate,
                    orderprocessed = orderDto.orderprocessed,
                    Items = orderDto.Items.Select(i => new Item
                    {
                        Id = i.Id,
                        Quantity = i.Quantity,
                        Name = i.Name,
                        Price = i.Price
                    }).ToList()
                });

                return new OrderDto
                {
                    Id = orderDto.Id,
                    orderdate = orderDto.orderdate,
                    orderprocessed = orderDto.orderprocessed,
                    Items = orderDto.Items
                };
            }
            else
            {
                _orderRepository.Update(desiredOrder, new Order
                {
                    orderdate = orderDto.orderdate,
                    orderprocessed = orderDto.orderprocessed,
                    Items = orderDto.Items.Select(i => new Item
                    {
                        Id = i.Id,
                        Quantity = i.Quantity,
                        Name = i.Name,
                        Price = i.Price
                    }).ToList()
                });
            }

            return new OrderDto
            {
                Id = desiredOrder.Id,
                orderdate = desiredOrder.orderdate,
                orderprocessed = desiredOrder.orderprocessed,
                Items = desiredOrder.Items.Select(itemModel => new ItemDto
                {
                    Id = itemModel.Id,
                    Quantity = itemModel.Quantity,
                    Name = itemModel.Name,
                    Price = itemModel.Price
                }).ToList()
            };
        }
    }
}