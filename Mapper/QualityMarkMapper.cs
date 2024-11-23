using System;
using System.Drawing.Drawing2D;
using System.Linq;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class QualityMarkMapper
    {
        public static QualityMarkDto ToResponseDto(this QualityMark qualityMark)
        {
            ArgumentNullException.ThrowIfNull(qualityMark, nameof(qualityMark));

            return new QualityMarkDto
            {
                QualityMarkId = qualityMark.QualityMarkId,
                Name = qualityMark.Name,
                CreateDateTime = qualityMark.CreateDateTime,
                UpdateDateTime = qualityMark.UpdateDateTime,
            };
        }

        public static QualityMarkInput ToInputModel(this CreateQualityMarkDto qualityMarkDto)
        {
            ArgumentNullException.ThrowIfNull(qualityMarkDto, nameof(qualityMarkDto));

            return new QualityMarkInput
            {
                Name = qualityMarkDto.Name,
            };
        }

        public static QualityMarkInput ToInputModel(this UpdateQualityMarkDto qualityMarkDto)
        {
            ArgumentNullException.ThrowIfNull(qualityMarkDto, nameof(qualityMarkDto));

            return new QualityMarkInput
            {
                Name = qualityMarkDto.Name,
            };
        }
    }
}
