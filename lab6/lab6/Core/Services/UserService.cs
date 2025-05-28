using System;
using System.Linq;
using lab6.Models;

namespace lab6.Core.Services
{
    public class UserService : IUserService
    {
        public User? Authenticate(string login, string password)
        {
            using var db = new MineSweeperDbContext();
            var user = db.Users.FirstOrDefault(u => u.Login == login);
            if (user == null || user.Password != password)
                return null;
            return user;
        }

        public User Register(string login, string password)
        {
            using var db = new MineSweeperDbContext();
            if (db.Users.Any(u => u.Login == login))
                throw new InvalidOperationException("User login are taken");

            var user = new User { Login = login, Password = password };
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }
    }
}
