using System;
using System.Data;
using System.Linq;
using Microsoft.Extensions.Hosting;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class RegionMapper(IRegion region) : IMapper<IRegion, RegionRequestDto, RegionResponseDto>
    {
        public RegionResponseDto ToResponseDto(IRegion entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new RegionResponseDto
            {
                RegionId = entity.RegionId,
                Name = entity.Name,
            };
        }

        public IRegion ToEntity(RegionRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            region.Name = dto.Name;

            return region;
        }
    }
}
