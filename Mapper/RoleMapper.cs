using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class RoleMapper
    {
        public static RoleDto ToResponseDto(this Role role)
        {
            ArgumentNullException.ThrowIfNull(role, nameof(role));

            return new RoleDto
            {
                RoleId = role.RoleId,
                Name = role.Name
            };
        }

        public static RoleInput ToInputModel(this CreateRoleDto roleDto)
        {
            ArgumentNullException.ThrowIfNull(roleDto, nameof(roleDto));

            return new RoleInput
            {
                Name = roleDto.Name
            };
        }

        public static RoleInput ToInputModel(this UpdateRoleDto roleDto)
        {
            ArgumentNullException.ThrowIfNull(roleDto, nameof(roleDto));

            return new RoleInput
            {
                Name = roleDto.Name
            };
        }
    }
}
