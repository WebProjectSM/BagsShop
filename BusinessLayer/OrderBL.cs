using DataLayer;
using Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;

namespace BusinessLayer
{
    public class OrderBL : IOrderBL
    {

        readonly IOrderDL _dl;
        readonly ILogger _logger;
        public OrderBL(IOrderDL Orderdl,ILogger<OrderBL> logger)
        {
            _dl = Orderdl;
            _logger = logger;
        }
     
        public async Task<Order> getOrderById(int id)
        {
            Order Order = await _dl.getOrderById(id);
            if (Order != null)
                return Order;
            return null;
        }
        public async Task<Order> addOrder(Order newOrder)
        {
            int realSum = await checkOrderSum(newOrder);
            if(realSum!=newOrder.OrderSum)
            {
                newOrder.OrderSum = realSum;
                _logger.LogInformation($" in Order {newOrder.OrderId} the user {newOrder.UserId} try to change his order price");
            }
            Order order = await _dl.addOrder(newOrder);
            if (order != null)
            {
                return order;
            }
            return null;
        }

        public async void update(int id, Order Order)
        {
            _dl.update(id, Order);
        }

        public async Task<int> checkOrderSum(Order order)
        {
            int realSum = 0;

            //order.OrderItems.ToList().ForEach(async item =>
            //{
            //    Product product = await _dl.findProduct(item.ProductId);
            //    realSum += product.Price * item.Quantity;

            //});
            foreach (var item in order.OrderItems.ToList())
            {
                Product product = await _dl.findProduct(item.ProductId);
                realSum += product.Price * item.Quantity;
            }
            return realSum;
        }

    }
}