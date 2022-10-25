using SocialNetwork.Context;
using SocialNetwork.DataLayer.Models;
using SocialNetwork.DataLayer.Repositories;

namespace SocialNetwork.DataLayer.Services
{
    internal class UserRepository : IUserRepository
    {

        private readonly SocialContext _context;

        public UserRepository(SocialContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            try
            {
                if (UserEmailExists(user.Email))
                    return false;
                if (UserNameExists(user.UserName))
                    return false;

                _context.Users.Add(user);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {

            try
            {
                DeleteUser(GetUserById(userId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _context.Users.FirstOrDefault(user).IsDeletedAccount = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(u => u.IsDeletedAccount == false).FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Where(u => u.IsDeletedAccount == false).FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.Where(u => u.IsDeletedAccount == false).FirstOrDefault(u => u.UserName == username);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UserEmailExists(string email)
        {
            return _context.Users.Where(u => u.IsDeletedAccount == false).Any(u => u.Email == email);
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Where(x => x.IsDeletedAccount == false).Any(u => u.Id == userId);
        }

        public bool UserNameExists(string username)
        {
            return _context.Users.Where(u => u.IsDeletedAccount == false).Any(u => u.UserName == username);
        }
    }
}
