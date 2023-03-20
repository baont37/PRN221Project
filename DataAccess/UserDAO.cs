using BusinessObjects;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {

        public List<User> GetUsers()
        {
            var users = new List<User>();
            try
            {
                using (var context = new MyDbContext())
                {
                    users = context.Users.ToList();

                    if (users == null)
                    {
                        throw new Exception("No Users!");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return users;
        }

        public UserDTO GetUserByUid(string uid)
        {
            var user = new User();
            try
            {
                using (var context = new MyDbContext())
                {
                    user = context.Users.FirstOrDefault(o=>o.Uid==uid);
                }
                var userDTO = new UserDTO()
                {
                    UserId = user.UserId,
                    Uid = user.Uid,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    AvtUrl = user.AvtUrl,
                    Email = user.Email,
                    Role = user.Role
                };
                return userDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }   
        }

        public void AddUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
