using Entities;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IUserBL
    {
        Task<User> addUser(User usr);
        Task<User> getUser(string name, string password);
        Task<User> getUserById(int id);
        void update(int id, User user);

    }
}