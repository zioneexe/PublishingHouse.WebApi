using System;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.WebApi.Dto;
using PublishingHouse.WebApi.Dto.Request;
using PublishingHouse.WebApi.Dto.Response;
using PublishingHouse.WebApi.Mapper.General;

namespace PublishingHouse.WebApi.Mapper
{
    public class BookMapper(IBook book) : IMapper<IBook, BookRequestDto, BookResponseDto>
    {
        public BookResponseDto ToResponseDto(IBook entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            return new BookResponseDto
            {
                BookId = entity.BookId,
                Name = entity.Name,
                Author = entity.Author,
                Genre = entity.Genre,
                Sku = entity.Sku,
                Isbn = entity.Isbn,
                Pages = entity.Pages,
                PublicationYear = entity.PublicationYear,
                Size = entity.Size,
                Weight = entity.Weight,
                Annotation = entity.Annotation,
                CoverImagePath = entity.CoverImagePath,
            };
        }

        public IBook ToEntity(BookRequestDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            book.Name = dto.Name;
            book.Author = dto.Author;
            book.Genre = dto.Genre;
            book.Sku = dto.Sku;
            book.Isbn = dto.Isbn;
            book.Pages = dto.Pages;
            book.PublicationYear = dto.PublicationYear;
            book.Size = dto.Size;
            book.Weight = dto.Weight;
            book.Annotation = dto.Annotation;
            book.CoverImagePath = dto.CoverImagePath;

            return book;
        }

    }
}