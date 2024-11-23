using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class ProductionTypeMapper
    {
        public static ProductionTypeDto ToResponseDto(this ProductionType productionType)
        {
            ArgumentNullException.ThrowIfNull(productionType, nameof(productionType));

            return new ProductionTypeDto
            {
                ProductionTypeId = productionType.ProductionTypeId,
                Name = productionType.Name,
                CreateDateTime = productionType.CreateDateTime,
                UpdateDateTime = productionType.UpdateDateTime
            };
        }

        public static ProductionTypeInput ToInputModel(this CreateProductionTypeDto productionTypeDto)
        {
            ArgumentNullException.ThrowIfNull(productionTypeDto, nameof(productionTypeDto));

            return new ProductionTypeInput
            {
                Name = productionTypeDto.Name,
            };
        }

        public static ProductionTypeInput ToInputModel(this UpdateProductionTypeDto productionTypeDto)
        {
            ArgumentNullException.ThrowIfNull(productionTypeDto, nameof(productionTypeDto));

            return new ProductionTypeInput
            {
                Name = productionTypeDto.Name,
            };
        }
    }
}
