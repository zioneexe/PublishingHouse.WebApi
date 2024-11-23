using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class BatchPrintMapper
    {
        public static BatchPrintDto ToResponseDto(this BatchPrint batchPrint)
        {
            ArgumentNullException.ThrowIfNull(batchPrint, nameof(batchPrint));

            return new BatchPrintDto
            {
                BatchPrintId = batchPrint.BatchPrintId,
                Number = batchPrint.Number,
                BookQuantity = batchPrint.BookQuantity,
                OrderId = batchPrint.OrderId,
                PrintDate = batchPrint.PrintDate,
                QualityMarkId = batchPrint.QualityMarkId,
                CreateDateTime = batchPrint.CreateDateTime,
                UpdateDateTime = batchPrint.UpdateDateTime,
            };
        }

        public static BatchPrintInput ToInputModel(this CreateBatchPrintDto batchPrintDto)
        {
            ArgumentNullException.ThrowIfNull(batchPrintDto, nameof(batchPrintDto));

            return new BatchPrintInput
            {
                Number = batchPrintDto.Number,
                BookQuantity = batchPrintDto.BookQuantity,
                OrderId = batchPrintDto.OrderId,
                PrintDate = batchPrintDto.PrintDate,
                QualityMarkId = batchPrintDto.QualityMarkId,
            };
        }

        public static BatchPrintInput ToInputModel(this UpdateBatchPrintDto batchPrintDto)
        {
            ArgumentNullException.ThrowIfNull(batchPrintDto, nameof(batchPrintDto));

            return new BatchPrintInput
            {
                Number = batchPrintDto.Number,
                BookQuantity = batchPrintDto.BookQuantity,
                OrderId = batchPrintDto.OrderId,
                PrintDate = batchPrintDto.PrintDate,
                QualityMarkId = batchPrintDto.QualityMarkId,
            };
        }
    }
}
