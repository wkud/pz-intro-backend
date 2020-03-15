using CRUD_Core.DTOs;
using CRUD_Core.Models;
using Flights.Core.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Core.Contexts
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public List<UserDto> UsersDto => Users.Select(user => UserMapper.MapToDto(user)).ToList();

        public void AddUser(UserDto userDto)
        {
            var user = UserMapper.MapToModel(userDto);
            Users.Add(user);
        }

        public void RemoveUser(long id)
        {
            var user = Users.Find(id);
            Users.Remove(user);
        }

        public void SetEntryState(UserDto userDto, EntityState state)
        {
            var user = UserMapper.MapToModel(userDto);
            this.Entry(user).State = state;
        }

        bool IUserContext.Contains(long id)
        {
            var user = Users.Find(id);
            return user != null;
        }

        void IUserContext.SaveChanges() => this.SaveChanges();
    }
}
