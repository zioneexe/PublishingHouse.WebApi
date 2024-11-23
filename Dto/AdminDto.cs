namespace PublishingHouse.WebApi.Dto;

public class AdminDto
{
    public int AdminId { get; set; }
    public int UserId { get; set; }
    public string? Department { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
    public string? UserName { get; set; }
}

public class CreateAdminDto
{
    public int UserId { get; set; }
    public string? Department { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
    public string? UserName { get; set; }
}

public class UpdateAdminDto
{
    public int UserId { get; set; }
    public string? Department { get; set; }
    public DateTime? CreateDateTime { get; set; }
    public DateTime? UpdateDateTime { get; set; }
    public string? UserName { get; set; }
}