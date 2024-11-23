using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class CityMapper
    {
        public static CityDto ToResponseDto(this City city)
        {
            ArgumentNullException.ThrowIfNull(city, nameof(city));

            return new CityDto
            {
                CityId = city.CityId,
                RegionId = city.RegionId,
                Name = city.Name,
                CreateDateTime = city.CreateDateTime,
                UpdateDateTime = city.UpdateDateTime,
            };
        }

        public static CityInput ToInputModel(this CreateCityDto cityDto)
        {
            ArgumentNullException.ThrowIfNull(cityDto, nameof(cityDto));

            return new CityInput
            {
                RegionId = cityDto.RegionId,
                Name = cityDto.Name,
            };
        }

        public static CityInput ToInputModel(this UpdateCityDto cityDto)
        {
            ArgumentNullException.ThrowIfNull(cityDto, nameof(cityDto));

            return new CityInput
            {
                RegionId = cityDto.RegionId,
                Name = cityDto.Name,
            };
        }
    }
}
