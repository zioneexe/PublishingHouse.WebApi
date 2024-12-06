using System;
using System.Drawing.Drawing2D;
using System.Linq;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class QualityMarkMapper(IQualityMark qualityMark) : IMapper<IQualityMark, QualityMarkRequestDto, QualityMarkResponseDto>
    {
        public QualityMarkResponseDto ToResponseDto(IQualityMark entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new QualityMarkResponseDto
            {
                QualityMarkId = entity.QualityMarkId,
                Name = entity.Name,
            };
        }

        public IQualityMark ToEntity(QualityMarkRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            qualityMark.Name = dto.Name;

            return qualityMark;
        }
    }
}
