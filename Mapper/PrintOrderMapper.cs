using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class PrintOrderMapper(IPrintOrder printOrder,
        IMapper<ICustomer, CustomerRequestDto, CustomerResponseDto> customerMapper,
        IMapper<IEmployee, EmployeeRequestDto, EmployeeResponseDto> employeeMapper,
        IMapper<IOrderStatus, OrderStatusRequestDto, OrderStatusResponseDto> orderStatusMapper
        ) : IMapper<IPrintOrder, PrintOrderRequestDto, PrintOrderResponseDto>
    {
        public PrintOrderResponseDto ToResponseDto(IPrintOrder entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new PrintOrderResponseDto
            {
                OrderId = entity.OrderId,
                Number = entity.Number,
                PrintType = entity.PrintType,
                PaperType = entity.PaperType,
                CoverType = entity.CoverType,
                FasteningType = entity.FasteningType,
                IsLaminated = entity.IsLaminated,
                Price = entity.Price,
                RegistrationDate = entity.RegistrationDate,
                CompletionDate = entity.CompletionDate,
                Customer = customerMapper.ToResponseDto(entity.Customer),
                Employee = employeeMapper.ToResponseDto(entity.Employee),
                OrderStatus = orderStatusMapper.ToResponseDto(entity.OrderStatus),
            };
        }

        public IPrintOrder ToEntity(PrintOrderRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            printOrder.Number = dto.Number;
            printOrder.PrintType = dto.PrintType;
            printOrder.PaperType = dto.PaperType;
            printOrder.CoverType = dto.CoverType;
            printOrder.FasteningType = dto.FasteningType;
            printOrder.IsLaminated = dto.IsLaminated;
            printOrder.Price = dto.Price;
            printOrder.OrderStatusId = dto.OrderStatusId;
            printOrder.RegistrationDate = dto.RegistrationDate;
            printOrder.CompletionDate = dto.CompletionDate;
            printOrder.CustomerId = dto.CustomerId;
            printOrder.EmployeeId = dto.EmployeeId;

            return printOrder;
        }
    }
}
