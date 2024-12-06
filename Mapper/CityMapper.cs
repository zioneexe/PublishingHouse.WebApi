using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class CityMapper(ICity city) : IMapper<ICity, CityRequestDto, CityResponseDto>
    {
        public CityResponseDto ToResponseDto(ICity entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new CityResponseDto
            {
                CityId = entity.CityId,
                RegionId = entity.RegionId,
                Name = entity.Name,
            };
        }

        public ICity ToEntity(CityRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            city.RegionId = dto.RegionId;
            city.Name = dto.Name;

            return city;
        }
    }
}
