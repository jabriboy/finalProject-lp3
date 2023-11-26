using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using finalProject_lp3.MODEL;
using finalProject_lp3.DAL.DBContext;


namespace finalProject_lp3.BLL
{
    public static class UserRepository
    {
        public static User addUser(User _u)
        {
            using (var dbContext = new Dbcontext())
            {
                dbContext.Add(_u);
                dbContext.SaveChanges();
            }
            return _u;
        }

        public static User removeUser(User _u)
        {
            using (var dbContext = new Dbcontext())
            {
                dbContext.Remove(_u);
                dbContext.SaveChanges();
            }
            return _u;
        }

        public static User getById(int id)
        {
            using(var dbContext = new Dbcontext())
            {
                try
                {
                    var User = dbContext.Users.Single(p => p.Id == id);
                    return User;

                } catch
                {
                    return null;
                }
            }
        }

        public static User getByUsername(string username)
        {
            using (var dbContext = new Dbcontext())
            {
                try
                {
                    var User = dbContext.Users.Single(p => p.Username == username);
                    return User;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static User verifyLogin(User user)
        {
            using (var dbContext = new Dbcontext())
            {
                try
                {
                    var User = dbContext.Users.Single(p => p.Username == user.Username);
                    if(User == null || user.Password != User.Password) { return null; }
                    return User;

                }
                catch
                {
                    return null;
                }
            }
        }

        public static List<User> getAll()
        {
            using (var dbContext = new Dbcontext())
            {
                var users = dbContext.Users.ToList();
                return users;
            }
        }

    }
}
