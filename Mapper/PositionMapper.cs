using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class PositionMapper(IPosition position) : IMapper<IPosition, PositionRequestDto, PositionResponseDto>
    {
        public PositionResponseDto ToResponseDto(IPosition entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new PositionResponseDto
            {
                PositionId = entity.PositionId,
                Name = entity.Name,
            };
        }

        public IPosition ToEntity(PositionRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            position.Name = dto.Name;

            return position;
        }
    }
}
