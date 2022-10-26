﻿using SocialNetwork.Context;
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
                _context.Users.Find(user).IsDeletedAccount = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.Where(u => !u.IsDeletedAccount).FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Where(u => !u.IsDeletedAccount).FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.Where(u => !u.IsDeletedAccount).FirstOrDefault(u => u.UserName == username);
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
            return _context.Users.Where(u => !u.IsDeletedAccount).Any(u => u.Email == email);
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Where(u => !u.IsDeletedAccount).Any(u => u.Id == userId);
        }

        public bool UserNameAndEmailExists(string username, string email)
        {
            return _context.Users.Where(u => !u.IsDeletedAccount).Any(u => u.Email == email || u.UserName == username);
        }

        public bool UserNameExists(string username)
        {
            return _context.Users.Where(u => !u.IsDeletedAccount).Any(u => u.UserName == username);
        }
    }
}
