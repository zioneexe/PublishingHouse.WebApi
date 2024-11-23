using System;
using Humanizer.Localisation;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class EmployeeMapper
    {
        public static EmployeeDto ToResponseDto(this Employee employee)
        {
            ArgumentNullException.ThrowIfNull(employee, nameof(employee));

            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                UserId = employee.UserId,
                PositionId = employee.PositionId,
                ProductionId = employee.ProductionId,
                CreateDateTime = employee.CreateDateTime,
                UpdateDateTime = employee.UpdateDateTime,
            };
        }

        public static EmployeeInput ToInputModel(this CreateEmployeeDto employeeDto)
        {
            ArgumentNullException.ThrowIfNull(employeeDto, nameof(employeeDto));

            return new EmployeeInput
            {
                UserId = employeeDto.UserId,
                PositionId = employeeDto.PositionId,
                ProductionId = employeeDto.ProductionId,
            };
        }

        public static EmployeeInput ToInputModel(this UpdateEmployeeDto employeeDto)
        {
            ArgumentNullException.ThrowIfNull(employeeDto, nameof(employeeDto));

            return new EmployeeInput
            {
                UserId = employeeDto.UserId,
                PositionId = employeeDto.PositionId,
                ProductionId = employeeDto.ProductionId,
            };
        }
    }
}
