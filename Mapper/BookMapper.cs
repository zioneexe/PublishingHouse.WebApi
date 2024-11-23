using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class BookMapper
    { 
        
        public static BookDto ToResponseDto(this Book book)
        {
            ArgumentNullException.ThrowIfNull(book, nameof(book));

            return new BookDto
            {
                BookId = book.BookId,
                Name = book.Name,
                AuthorId = book.AuthorId,
                GenreId = book.GenreId,
                Sku = book.Sku,
                Isbn = book.Isbn,
                Pages = book.Pages,
                PublicationYear = book.PublicationYear,
                Size = book.Size,
                Weight = book.Weight,
                Annotation = book.Annotation,
                CreateDateTime = book.CreateDateTime,
                UpdateDateTime = book.UpdateDateTime,
            };
        }

       
        public static BookInput ToInputModel(this CreateBookDto bookDto)
        {
            ArgumentNullException.ThrowIfNull(bookDto, nameof(bookDto));

            return new BookInput
            {
                Name = bookDto.Name,
                AuthorId = bookDto.AuthorId,
                GenreId = bookDto.GenreId,
                Sku = bookDto.Sku,
                Isbn = bookDto.Isbn,
                Pages = bookDto.Pages,
                PublicationYear = bookDto.PublicationYear,
                Size = bookDto.Size,
                Weight = bookDto.Weight,
                Annotation = bookDto.Annotation,
            };
        }

        public static BookInput ToInputModel(this UpdateBookDto bookDto)
        {
            ArgumentNullException.ThrowIfNull(bookDto, nameof(bookDto));

            return new BookInput
            {
                Name = bookDto.Name,
                AuthorId = bookDto.AuthorId,
                GenreId = bookDto.GenreId,
                Sku = bookDto.Sku,
                Isbn = bookDto.Isbn,
                Pages = bookDto.Pages,
                PublicationYear = bookDto.PublicationYear,
                Size = bookDto.Size,
                Weight = bookDto.Weight,
                Annotation = bookDto.Annotation,
            };
        }
    }
}
