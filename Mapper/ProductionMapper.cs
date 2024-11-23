using System;
using System.Collections.Generic;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class ProductionMapper
    {
        public static ProductionDto ToResponseDto(this Production production)
        {
            ArgumentNullException.ThrowIfNull(production, nameof(production));

            return new ProductionDto
            {
                ProductionId = production.ProductionId,
                ProductionTypeId = production.ProductionTypeId,
                CityId = production.CityId,
                Address = production.Address,
                CreateDateTime = production.CreateDateTime,
                UpdateDateTime = production.UpdateDateTime,
            };
        }

        public static ProductionInput ToInputModel(this CreateProductionDto productionDto)
        {
            ArgumentNullException.ThrowIfNull(productionDto, nameof(productionDto));

            return new ProductionInput
            {
                ProductionTypeId = productionDto.ProductionTypeId,
                CityId = productionDto.CityId,
                Address = productionDto.Address,
            };
        }

        public static ProductionInput ToInputModel(this UpdateProductionDto productionDto)
        {
            ArgumentNullException.ThrowIfNull(productionDto, nameof(productionDto));

            return new ProductionInput
            {
                ProductionTypeId = productionDto.ProductionTypeId,
                CityId = productionDto.CityId,
                Address = productionDto.Address,
            };
        }
    }
}
