using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class PositionMapper
    {
        public static PositionDto ToResponseDto(this Position position)
        {
            ArgumentNullException.ThrowIfNull(position, nameof(position));

            return new PositionDto
            {
                PositionId = position.PositionId,
                Name = position.Name,
                CreateDateTime = position.CreateDateTime,
                UpdateDateTime = position.UpdateDateTime
            };
        }

        public static PositionInput ToInputModel(this CreatePositionDto positionDto)
        {
            ArgumentNullException.ThrowIfNull(positionDto, nameof(positionDto));

            return new PositionInput
            {
                Name = positionDto.Name,
            };
        }

        public static PositionInput ToInputModel(this UpdatePositionDto positionDto)
        {
            ArgumentNullException.ThrowIfNull(positionDto, nameof(positionDto));

            return new PositionInput
            {
                Name = positionDto.Name,
            };
        }
    }
}
