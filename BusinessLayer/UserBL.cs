using DataLayer;
using Entities;
using System.Text.Json;
using System.Threading.Tasks;
using Zxcvbn;

namespace BusinessLayer
{
    public class UserBL : IUserBL
    {
        string filePath = "M:/web-api/myWebApp/wwwroot/users.txt";
        readonly IuserDL _dl;
        public UserBL(IuserDL userdl)
        {
            _dl = userdl;
        }
        public async Task<User> getUser(string name, string password)
        {

            User user = await _dl.getUser(name, password);
            if (user != null)
            {

                return user;
            }
            return null;
        }
        public async Task<User> getUserById(int id)
        {
            User user = await _dl.getUserById(id);
            if (user != null)
                return user;
            return null;
        }
        public async Task<User> addUser(User usr)
        {
            User user = await _dl.addUser(usr);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async void update(int id, User user)
        {
            _dl.update(id, user);
        }
        
       

    }
}