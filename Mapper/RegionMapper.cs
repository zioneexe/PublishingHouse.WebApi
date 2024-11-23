using System;
using System.Data;
using System.Linq;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class RegionMapper
    {
        public static RegionDto ToResponseDto(this Region region)
        {
            ArgumentNullException.ThrowIfNull(region, nameof(region));

            return new RegionDto
            {
                RegionId = region.RegionId,
                Name = region.Name,
                CreateDateTime = region.CreateDateTime,
                UpdateDateTime = region.UpdateDateTime,
            };
        }

        public static RegionInput ToInputModel(this CreateRegionDto regionDto)
        {
            ArgumentNullException.ThrowIfNull(regionDto, nameof(regionDto));

            return new RegionInput
            {
                Name = regionDto.Name,
            };
        }

        public static RegionInput ToInputModel(this UpdateRegionDto regionDto)
        {
            ArgumentNullException.ThrowIfNull(regionDto, nameof(regionDto));

            return new RegionInput
            {
                Name = regionDto.Name,
            };
        }
    }
}
