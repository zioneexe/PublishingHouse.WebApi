namespace PublishingHouse.WebApi.Dto;

public class AuthorDto
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class CreateAuthorDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}

public class UpdateAuthorDto
{
    public string? Name { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
}