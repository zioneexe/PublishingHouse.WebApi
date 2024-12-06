using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class OrderBookMapper(IOrderBook orderBook,
        IMapper<IBook, BookRequestDto, BookResponseDto> bookMapper
        ) : IMapper<IOrderBook, OrderBookRequestDto, OrderBookResponseDto>
    {
        public OrderBookResponseDto ToResponseDto(IOrderBook entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new OrderBookResponseDto
            {
                OrderId = entity.OrderId,
                BookId = entity.BookId,
                BookQuantity = entity.BookQuantity,
                Book = bookMapper.ToResponseDto(entity.Book)
            };
        }

        public IOrderBook ToEntity(OrderBookRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            orderBook.OrderId = dto.OrderId;
            orderBook.BookId = dto.BookId;
            orderBook.BookQuantity = dto.BookQuantity;

            return orderBook;
        }
    }
}
