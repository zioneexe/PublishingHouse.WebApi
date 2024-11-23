using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class CustomerMapper
    {
        public static CustomerDto ToResponseDto(this Customer customer)
        {
            ArgumentNullException.ThrowIfNull(customer, nameof(customer));

            return new CustomerDto
            {
                CustomerId = customer.CustomerId,
                CustomerTypeId = customer.CustomerTypeId,
                Name = customer.Name,
                AddressDate = customer.AddressDate,
                Email = customer.Email,
                CreateDateTime = customer.CreateDateTime,
                UpdateDateTime = customer.UpdateDateTime,
            };
        }

        public static CustomerInput ToInputModel(this CreateCustomerDto customerDto)
        {
            ArgumentNullException.ThrowIfNull(customerDto, nameof(customerDto));

            return new CustomerInput
            {
                CustomerTypeId = customerDto.CustomerTypeId,
                Name = customerDto.Name,
                AddressDate = customerDto.AddressDate,
                Email = customerDto.Email,
            };
        }

        public static CustomerInput ToInputModel(this UpdateCustomerDto customerDto)
        {
            ArgumentNullException.ThrowIfNull(customerDto, nameof(customerDto));

            return new CustomerInput
            {
                CustomerTypeId = customerDto.CustomerTypeId,
                Name = customerDto.Name,
                AddressDate = customerDto.AddressDate,
                Email = customerDto.Email,
            };
        }
    }
}
