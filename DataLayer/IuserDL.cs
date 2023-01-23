using Entities;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IuserDL
    {
        Task<User> addUser(User value);
      Task<User> getUser(string password, string name);
        Task<User> getUserById(int id);
        void  update(int id, User userToUpdate);
    }
}