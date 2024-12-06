using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.AuthDto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class EmployeeMapper(IEmployee employee) : IMapper<IEmployee, EmployeeRequestDto, EmployeeResponseDto>
    {
        public EmployeeResponseDto ToResponseDto(IEmployee entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new EmployeeResponseDto
            {
                EmployeeId = entity.EmployeeId,
                PositionId = entity.PositionId,
                ProductionId = entity.ProductionId,
                Name = entity.Name,
            };
        }

        public IEmployee ToEntity(EmployeeRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            employee.PositionId = dto.PositionId;
            employee.ProductionId = dto.ProductionId;
            employee.Name = dto.Name;

            return employee;
        }
    }
}
