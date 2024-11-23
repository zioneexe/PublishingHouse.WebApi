namespace PublishingHouse.WebApi.Dto;

public class GenreDto
{
    public int GenreId { get; set; }
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateGenreDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateGenreDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}