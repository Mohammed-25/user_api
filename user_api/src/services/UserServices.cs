using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductAppAsync.src.config.DB;

namespace ProductApplication.Models
{
    public class UsersServices : IUserService
    {
        private readonly AppDbContext _context;

        public UsersServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            var users = _context.Users.ToListAsync();
            return await users;
        }

        public async Task<Users> AddUser(Users newUser)
        {

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        public async Task<Users> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            return user;
        }
        public async Task<Users> UodateUser(int id, Users updatedUser)
        {
            var exisitingUser = await _context.Users.FindAsync(id);
            if (exisitingUser == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found");
            }
            exisitingUser.userName = updatedUser.userName;
            exisitingUser.email = updatedUser.email;
            exisitingUser.adreess = updatedUser.adreess;
            await _context.SaveChangesAsync();
            return exisitingUser;
        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return;
        }
    }
}