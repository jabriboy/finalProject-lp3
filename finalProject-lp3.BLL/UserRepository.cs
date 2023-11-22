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
            using (var dbContext = new DbContext())
            {
                dbContext.Add(_u);
                dbContext.SaveChanges();
            }
            return _u;
        }

        public static User removeUser(User _u)
        {
            using (var dbContext = new DbContext())
            {
                dbContext.Remove(_u);
                dbContext.SaveChanges();
            }
            return _u;
        }

        public static User getById(int id)
        {
            using(var dbContext = new DbContext())
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

        public static List<User> getAll()
        {
            using (var dbContext = new DbContext())
            {
                var users = dbContext.Users.ToList();
                return users;
            }
        }

    }
}
