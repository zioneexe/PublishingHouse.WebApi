using System;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;
using PublishingHouse.Shared.Model.Input;
using PublishingHouse.WebApi.Dto;

namespace PublishingHouse.WebApi.Mapper
{
    public static class GenreMapper
    {
        public static GenreDto ToResponseDto(this Genre genre)
        {
            ArgumentNullException.ThrowIfNull(genre, nameof(genre));

            return new GenreDto
            {
                GenreId = genre.GenreId,
                Name = genre.Name,
                CreateDateTime = genre.CreateDateTime,
                UpdateDateTime = genre.UpdateDateTime
            };
        }

        public static GenreInput ToInputModel(this CreateGenreDto genreDto)
        {
            ArgumentNullException.ThrowIfNull(genreDto, nameof(genreDto));

            return new GenreInput
            {
                Name = genreDto.Name,
            };
        }

        public static GenreInput ToInputModel(this UpdateGenreDto genreDto)
        {
            ArgumentNullException.ThrowIfNull(genreDto, nameof(genreDto));

            return new GenreInput
            {
                Name = genreDto.Name,
            };
        }
    }
}
