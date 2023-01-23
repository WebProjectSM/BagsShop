using Entities;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IOrderDL
    {
        Task<Order> addOrder(Order OrderToAdd);
        Task<Order> getOrderById(int id);
        void update(int id, Order Order);
    }
}