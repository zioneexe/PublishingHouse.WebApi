using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class BatchPrintMapper(IBatchPrint batchPrint) : IMapper<IBatchPrint, BatchPrintRequestDto, BatchPrintResponseDto>
    {
        public BatchPrintResponseDto ToResponseDto(IBatchPrint entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new BatchPrintResponseDto
            {
                BatchPrintId = entity.BatchPrintId,
                Number = entity.Number,
                BookQuantity = entity.BookQuantity,
                OrderId = entity.OrderId,
                PrintDate = entity.PrintDate,
                QualityMarkId = entity.QualityMarkId,
            };
        }

        public IBatchPrint ToEntity(BatchPrintRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            batchPrint.Number = dto.Number;
            batchPrint.BookQuantity = dto.BookQuantity;
            batchPrint.OrderId = dto.OrderId;
            batchPrint.PrintDate = dto.PrintDate;
            batchPrint.QualityMarkId = dto.QualityMarkId;

            return batchPrint;
        }
    }
}

