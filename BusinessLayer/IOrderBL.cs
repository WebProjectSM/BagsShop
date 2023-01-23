using Entities;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IOrderBL
    {
        Task<Order> addOrder(Order usr);
        Task<Order> getOrderById(int id);
        void update(int id, Order Order);
    }
}