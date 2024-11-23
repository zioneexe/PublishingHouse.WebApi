using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToResponseDto(this User user)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));

            return new UserDto
            {
                UserId = user.UserId,
                RoleId = user.RoleId,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CreateDateTime = user.CreateDateTime,
                UpdateDateTime = user.UpdateDateTime,
            };
        }

        public static UserInput ToInputModel(this CreateUserDto userDto)
        {
            ArgumentNullException.ThrowIfNull(userDto, nameof(userDto));

            return new UserInput
            {
                RoleId = userDto.RoleId,
                Username = userDto.Username,
                PasswordHash = userDto.PasswordHash,
                FullName = userDto.FullName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
            };
        }

        public static UserInput ToInputModel(this UpdateUserDto userDto)
        {
            ArgumentNullException.ThrowIfNull(userDto, nameof(userDto));

            return new UserInput
            {
                RoleId = userDto.RoleId,
                Username = userDto.Username,
                FullName = userDto.FullName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
            };
        }
    }
}
