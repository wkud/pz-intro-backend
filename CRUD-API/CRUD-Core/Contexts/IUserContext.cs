using CRUD_Core.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Core.Contexts
{
    public interface IUserContext
    {
        public List<UserDto> UsersDto { get; }

        void SetEntryState(UserDto userDto, EntityState state);
        void AddUser(UserDto userDto);
        void SaveChanges();
        bool Contains(long id);
        void RemoveUser(long id);
        
    }
}
