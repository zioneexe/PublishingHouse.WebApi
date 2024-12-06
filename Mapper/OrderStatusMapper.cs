using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class OrderStatusMapper(IOrderStatus orderStatus) : IMapper<IOrderStatus, OrderStatusRequestDto, OrderStatusResponseDto>
    {
        public OrderStatusResponseDto ToResponseDto(IOrderStatus entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new OrderStatusResponseDto
            {
                OrderStatusId = entity.OrderStatusId,
                Name = entity.Name,
            };
        }

        public IOrderStatus ToEntity(OrderStatusRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            orderStatus.Name = dto.Name;

            return orderStatus;
        }
    }
}
