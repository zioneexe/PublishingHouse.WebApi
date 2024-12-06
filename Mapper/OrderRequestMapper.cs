using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class OrderRequestMapper(IOrderRequest orderRequest,
        IMapper<ICustomer, CustomerRequestDto, CustomerResponseDto> customerMapper) : IMapper<IOrderRequest, OrderRequestRequestDto, OrderRequestResponseDto>
    {
        public OrderRequestResponseDto ToResponseDto(IOrderRequest entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new OrderRequestResponseDto
            {
                OrderRequestId = entity.OrderRequestId,
                BookName = entity.BookName,
                AuthorName = entity.AuthorName,
                Genre = entity.Genre,
                PublicationYear = entity.PublicationYear,
                Quantity = entity.Quantity,
                PrintType = entity.PrintType,
                PaperType = entity.PaperType,
                CoverType = entity.CoverType,
                FasteningType = entity.FasteningType,
                IsLaminated = entity.IsLaminated,
                CompletionDate = entity.CompletionDate,
                CoverImagePath = entity.CoverImagePath,
                Customer = customerMapper.ToResponseDto(entity.Customer),
            };
        }

        public IOrderRequest ToEntity(OrderRequestRequestDto requestDto)
        {
            ArgumentNullException.ThrowIfNull(requestDto, nameof(requestDto));

            orderRequest.CustomerId = requestDto.CustomerId;
            orderRequest.BookName = requestDto.BookName;
            orderRequest.AuthorName = requestDto.AuthorName;
            orderRequest.Genre = requestDto.Genre;
            orderRequest.PublicationYear = requestDto.PublicationYear;
            orderRequest.Quantity = requestDto.Quantity;
            orderRequest.PrintType = requestDto.PrintType;
            orderRequest.PaperType = requestDto.PaperType;
            orderRequest.CoverType = requestDto.CoverType;
            orderRequest.FasteningType = requestDto.FasteningType;
            orderRequest.IsLaminated = requestDto.IsLaminated;
            orderRequest.CoverImagePath = requestDto.CoverImagePath;
            orderRequest.CompletionDate = requestDto.CompletionDate;

            return orderRequest;
        }
    }
}