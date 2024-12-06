using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class CustomerTypeMapper(ICustomerType customerType) : IMapper<ICustomerType, CustomerTypeRequestDto, CustomerTypeResponseDto>
    {
        public CustomerTypeResponseDto ToResponseDto(ICustomerType entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new CustomerTypeResponseDto
            {
                CustomerTypeId = entity.CustomerTypeId,
                Name = entity.Name,
            };
        }

        public ICustomerType ToEntity(CustomerTypeRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            customerType.Name = dto.Name;

            return customerType;
        }
    }
}
