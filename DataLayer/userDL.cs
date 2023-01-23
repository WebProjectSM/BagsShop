using Entities;
using System.Text.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class userDL : IuserDL
    {
        readonly bagsContext _bagsDBContext;
        public userDL(bagsContext bagsDBContext)
        {
            _bagsDBContext = bagsDBContext;
        }



        public async Task<User> getUser(string Password, string Email)
        {
            var user = await (from userByPassword in _bagsDBContext.Users
                              where userByPassword.Password == Password && userByPassword.Email == Email
                              select userByPassword).ToListAsync();


            User u = user.FirstOrDefault();
            if (u != null)

                return u;
            else
            {
                throw new Exception("user not found");
                return null;
            }
        }

        public async Task<User> getUserById(int id)
        {
            User user = await _bagsDBContext.Users.FindAsync(id);
            if (user != null)
            
                return user;
          
                
            else return null;
        }
        public async Task<User> addUser(User userToAdd)
        {

            var res=await _bagsDBContext.Users.AddAsync(userToAdd);
            var res2=await _bagsDBContext.SaveChangesAsync();
            if(res2!=-1)
            //User tmpUser= await getUser(userToAdd.Password, userToAdd.Email);
            return userToAdd;
            else return null;

        }
        public async void update(int id, User user)
        {
            User userToUpdate = await _bagsDBContext.Users.FindAsync(id);
            if (userToUpdate != null) 
            {
                _bagsDBContext.Entry(userToUpdate).CurrentValues.SetValues(user);
                await _bagsDBContext.SaveChangesAsync();
            }

        }

    
    }

}