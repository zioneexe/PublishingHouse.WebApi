using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class ProductionTypeMapper(IProductionType productionType) : IMapper<IProductionType, ProductionTypeRequestDto, ProductionTypeResponseDto>
    {
        public ProductionTypeResponseDto ToResponseDto(IProductionType entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new ProductionTypeResponseDto
            {
                ProductionTypeId = entity.ProductionTypeId,
                Name = entity.Name,
            };
        }

        public IProductionType ToEntity(ProductionTypeRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            productionType.Name = dto.Name;

            return productionType;
        }
    }
}
