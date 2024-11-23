using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper;

public static class AuthorMapper
{

    public static AuthorDto ToResponseDto(this IAuthor author)
    {
        ArgumentNullException.ThrowIfNull(author, nameof(author));

        return new AuthorDto()
        {
            AuthorId = author.AuthorId,
            Name = author.Name,
            CreateDateTime = author.CreateDateTime,
            UpdateDateTime = author.UpdateDateTime
        };
    }

    public static AuthorInput ToInputModel(this CreateAuthorDto authorDto)
    {
        ArgumentNullException.ThrowIfNull(authorDto, nameof(authorDto));

        return new AuthorInput
        {
            Name = authorDto.Name,
        };
    }

    public static AuthorInput ToInputModel(this UpdateAuthorDto authorDto)
    {
        ArgumentNullException.ThrowIfNull(authorDto, nameof(authorDto));

        return new AuthorInput
        {
            Name = authorDto.Name,
        };
    }
}