using System;
using System.Collections.Generic;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class ProductionMapper(IProduction production) : IMapper<IProduction, ProductionRequestDto, ProductionResponseDto>
    {
        public ProductionResponseDto ToResponseDto(IProduction entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new ProductionResponseDto
            {
                ProductionId = entity.ProductionId,
                ProductionTypeId = entity.ProductionTypeId,
                CityId = entity.CityId,
                Address = entity.Address,
            };
        }

        public IProduction ToEntity(ProductionRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            production.ProductionTypeId = dto.ProductionTypeId;
            production.CityId = dto.CityId;
            production.Address = dto.Address;

            return production;
        }
    }
}
