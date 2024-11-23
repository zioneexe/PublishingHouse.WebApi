using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class OrderBookMapper
    {
        public static OrderBookDto ToResponseDto(this OrderBook orderBook)
        {
            ArgumentNullException.ThrowIfNull(orderBook, nameof(orderBook));

            return new OrderBookDto
            {
                OrderBookId = orderBook.OrderBooksId,
                OrderId = orderBook.OrderId,
                BookId = orderBook.BookId,
                BookQuantity = orderBook.BookQuantity,
                CreateDateTime = orderBook.CreateDateTime,
                UpdateDateTime = orderBook.UpdateDateTime,
            };
        }

        public static OrderBookInput ToInputModel(this CreateOrderBookDto orderBookDto)
        {
            ArgumentNullException.ThrowIfNull(orderBookDto, nameof(orderBookDto));

            return new OrderBookInput
            {
                OrderId = orderBookDto.OrderId,
                BookId = orderBookDto.BookId,
                BookQuantity = orderBookDto.BookQuantity,
            };
        }

        public static OrderBookInput ToInputModel(this UpdateOrderBookDto orderBookDto)
        {
            ArgumentNullException.ThrowIfNull(orderBookDto, nameof(orderBookDto));

            return new OrderBookInput
            {
                OrderId = orderBookDto.OrderId,
                BookId = orderBookDto.BookId,
                BookQuantity = orderBookDto.BookQuantity,
            };
        }
    }
}
