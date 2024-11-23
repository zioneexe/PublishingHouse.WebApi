using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class CustomerTypeMapper
    {
        public static CustomerTypeDto ToResponseDto(this CustomerType customerType)
        {
            ArgumentNullException.ThrowIfNull(customerType, nameof(customerType));

            return new CustomerTypeDto
            {
                CustomerTypeId = customerType.CustomerTypeId,
                Name = customerType.Name,
                CreateDateTime = customerType.CreateDateTime,
                UpdateDateTime = customerType.UpdateDateTime
            };
        }

        public static CustomerTypeInput ToInputModel(this CreateCustomerTypeDto customerTypeDto)
        {
            ArgumentNullException.ThrowIfNull(customerTypeDto, nameof(customerTypeDto));

            return new CustomerTypeInput
            {
                Name = customerTypeDto.Name,
            };
        }

        public static CustomerTypeInput ToInputModel(this UpdateCustomerTypeDto customerTypeDto)
        {
            ArgumentNullException.ThrowIfNull(customerTypeDto, nameof(customerTypeDto));

            return new CustomerTypeInput
            {
                Name = customerTypeDto.Name,
            };
        }
    }
}
