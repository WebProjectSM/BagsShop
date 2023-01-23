using DataLayer;
using Entities;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;

namespace BusinessLayer
{
    public class OrderBL : IOrderBL
    {

        readonly IOrderDL _dl;
        public OrderBL(IOrderDL Orderdl)
        {
            _dl = Orderdl;
        }

        public async Task<Order> getOrderById(int id)
        {
            Order Order = await _dl.getOrderById(id);
            if (Order != null)
                return Order;
            return null;
        }
        public async Task<Order> addOrder(Order usr)
        {
            Order Order = await _dl.addOrder(usr);
            if (Order != null)
            {
                return Order;
            }
            return null;
        }

        public async void update(int id, Order Order)
        {
            _dl.update(id, Order);
        }
       
    }
}