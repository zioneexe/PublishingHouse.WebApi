using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class PrintOrderMapper
    {
        public static PrintOrderDto ToResponseDto(this PrintOrder printOrder)
        {
            ArgumentNullException.ThrowIfNull(printOrder, nameof(printOrder));

            return new PrintOrderDto
            {
                OrderId = printOrder.OrderId,
                Number = printOrder.Number,
                PrintType = printOrder.PrintType,
                PaperType = printOrder.PaperType,
                CoverType = printOrder.CoverType,
                FasteningType = printOrder.FasteningType,
                IsLaminated = printOrder.IsLaminated,
                Price = printOrder.Price,
                OrderStatusId = printOrder.OrderStatusId,
                RegistrationDate = printOrder.RegistrationDate,
                CompletionDate = printOrder.CompletionDate,
                CustomerId = printOrder.CustomerId,
                EmployeeId = printOrder.EmployeeId,
                CreateDateTime = printOrder.CreateDateTime,
                UpdateDateTime = printOrder.UpdateDateTime,
            };
        }

        public static PrintOrderInput ToInputModel(this CreatePrintOrderDto printOrderDto)
        {
            ArgumentNullException.ThrowIfNull(printOrderDto, nameof(printOrderDto));

            return new PrintOrderInput
            {
                Number = printOrderDto.Number,
                PrintType = printOrderDto.PrintType,
                PaperType = printOrderDto.PaperType,
                CoverType = printOrderDto.CoverType,
                FasteningType = printOrderDto.FasteningType,
                IsLaminated = printOrderDto.IsLaminated,
                Price = printOrderDto.Price,
                OrderStatusId = printOrderDto.OrderStatusId,
                RegistrationDate = printOrderDto.RegistrationDate,
                CompletionDate = printOrderDto.CompletionDate,
                CustomerId = printOrderDto.CustomerId,
                EmployeeId = printOrderDto.EmployeeId,
            };
        }

        public static PrintOrderInput ToInputModel(this UpdatePrintOrderDto printOrderDto)
        {
            ArgumentNullException.ThrowIfNull(printOrderDto, nameof(printOrderDto));

            return new PrintOrderInput
            {
                Number = printOrderDto.Number,
                PrintType = printOrderDto.PrintType,
                PaperType = printOrderDto.PaperType,
                CoverType = printOrderDto.CoverType,
                FasteningType = printOrderDto.FasteningType,
                IsLaminated = printOrderDto.IsLaminated,
                Price = printOrderDto.Price,
                OrderStatusId = printOrderDto.OrderStatusId,
                RegistrationDate = printOrderDto.RegistrationDate,
                CompletionDate = printOrderDto.CompletionDate,
                CustomerId = printOrderDto.CustomerId,
                EmployeeId = printOrderDto.EmployeeId,
            };
        }
    }
}
