using System;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class OrderStatusMapper
    {
        public static OrderStatusDto ToResponseDto(this OrderStatus orderStatus)
        {
            ArgumentNullException.ThrowIfNull(orderStatus, nameof(orderStatus));

            return new OrderStatusDto
            {
                OrderStatusId = orderStatus.OrderStatusId,
                Name = orderStatus.Name,
                CreateDateTime = orderStatus.CreateDateTime,
                UpdateDateTime = orderStatus.UpdateDateTime
            };
        }

        public static OrderStatusInput ToInputModel(this CreateOrderStatusDto orderStatusDto)
        {
            ArgumentNullException.ThrowIfNull(orderStatusDto, nameof(orderStatusDto));

            return new OrderStatusInput
            {
                Name = orderStatusDto.Name,
            };
        }

        public static OrderStatusInput ToInputModel(this UpdateOrderStatusDto orderStatusDto)
        {
            ArgumentNullException.ThrowIfNull(orderStatusDto, nameof(orderStatusDto));

            return new OrderStatusInput
            {
                Name = orderStatusDto.Name,
            };
        }
    }
}
