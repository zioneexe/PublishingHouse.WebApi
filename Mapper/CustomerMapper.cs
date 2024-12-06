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
    public class CustomerMapper(ICustomer customer) : IMapper<ICustomer, CustomerRequestDto, CustomerResponseDto>, IUserMapper<ICustomer, RegisterCustomerRequestDto>
    {
        public CustomerResponseDto ToResponseDto(ICustomer entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new CustomerResponseDto
            {
                CustomerId = entity.CustomerId,
                CustomerTypeId = entity.CustomerTypeId,
                Name = entity.Name,
                AddressDate = entity.AddressDate,
                Email = entity.Email,
            };
        }

        public ICustomer ToEntity(CustomerRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            customer.CustomerTypeId = dto.CustomerTypeId;
            customer.Name = dto.Name;
            customer.AddressDate = dto.AddressDate;
            customer.Email = dto.Email;

            return customer;
        }

        public ICustomer ToEntity(RegisterCustomerRequestDto regDto, string userId)
        {
            ArgumentNullException.ThrowIfNull(regDto, nameof(regDto));

            customer.CustomerTypeId = Random.Shared.Next(1, 2);
            customer.Name = regDto.UserName;
            customer.AddressDate = DateOnly.FromDateTime(DateTime.UtcNow);
            customer.Email = regDto.Email;
            customer.UserId = userId;

            return customer;
        }
    }
}

