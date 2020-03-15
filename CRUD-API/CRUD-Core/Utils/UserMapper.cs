using CRUD_Core.DTOs;
using CRUD_Core.Models;

namespace Flights.Core.Utility
{
    public static class UserMapper
    {
        public static User MapToModel(UserDto dto)
        {
            var user = MapProperties(dto, new User());
            return user;
        }
        public static UserDto MapToDto(User model)
        {
            var dto = MapProperties(model, new UserDto());
            return dto;
        }

        private static TDestination MapProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            foreach (var srcProperty in source.GetType().GetProperties())
            {
                foreach (var dstProperty in destination.GetType().GetProperties())
                {
                    if (srcProperty.Name == dstProperty.Name &&
                        srcProperty.PropertyType == dstProperty.PropertyType)
                    {
                        dstProperty.SetValue(destination, srcProperty.GetValue(source));
                    }
                }
            }
            return destination;
        }
    }
}