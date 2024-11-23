using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper;

public static class AdminMapper
{
    public static AdminDto ToResponseDto(this Admin admin)
    {
        ArgumentNullException.ThrowIfNull(admin, nameof(admin));

        return new AdminDto
        {
            AdminId = admin.AdminId,
            UserId = admin.UserId,
            Department = admin.Department,
            CreateDateTime = admin.CreateDateTime,
            UpdateDateTime = admin.UpdateDateTime,
            UserName = admin.User?.Username
        };
    }

    public static AdminInput ToInputModel(this CreateAdminDto adminDto)
    {
        ArgumentNullException.ThrowIfNull(adminDto, nameof(adminDto));

        return new AdminInput
        {
            UserId = adminDto.UserId,
            Department = adminDto.Department,
        };
    }

    public static AdminInput ToInputModel(this UpdateAdminDto adminDto)
    {
        ArgumentNullException.ThrowIfNull(adminDto, nameof(adminDto));

        return new AdminInput
        {
            UserId = adminDto.UserId,
            Department = adminDto.Department,
        };
    }
}