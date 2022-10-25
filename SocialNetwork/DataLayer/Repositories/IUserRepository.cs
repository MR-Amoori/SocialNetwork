﻿using SocialNetwork.DataLayer.Models;

namespace SocialNetwork.DataLayer.Repositories
{
    public interface IUserRepository
    {
        public User GetUserById(int userId);
        public User GetUserByUsername(string username);
        public User GetUserByEmail(string email);
        public bool UserExists(int userId);
        public bool UserEmailExists(string email);
        public bool UserNameExists(string username);
        public bool AddUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int userId);
        public bool DeleteUser(User user);
        public void Save();
    }
}
