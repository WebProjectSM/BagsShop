using Entities;
using System.Text.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class OrderDL : IOrderDL
    {
        readonly bagsContext _bagsDBContext;
        public OrderDL(bagsContext bagsDBContext)
        {
            _bagsDBContext = bagsDBContext;
        }





        public async Task<Order> getOrderById(int id)
        {
            Order Order = await _bagsDBContext.Orders.FindAsync(id);
            if (Order != null)

                return Order;


            else return null;
        }
        public async Task<Order> addOrder(Order OrderToAdd)
        {

            await _bagsDBContext.Orders.AddAsync(OrderToAdd);
            await _bagsDBContext.SaveChangesAsync();
            //Order tmpOrder= await getOrder(OrderToAdd.Password, OrderToAdd.Email);
            return OrderToAdd;

        }
        public async void update(int id, Order Order)
        {
            Order OrderToUpdate = await _bagsDBContext.Orders.FindAsync(id);
            if (OrderToUpdate != null)
            {
                _bagsDBContext.Entry(OrderToUpdate).CurrentValues.SetValues(Order);
                await _bagsDBContext.SaveChangesAsync();
            }

        }

        public async Task<Product> findProduct(int id)
        {
            Product product = await _bagsDBContext.Products.FindAsync(id);
                return product;
        }


    }

}