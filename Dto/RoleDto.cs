namespace PublishingHouse.WebApi.Dto;

public class RoleDto
{
    public int RoleId { get; set; }
    public string Name { get; set; } = null!;
}

public class CreateRoleDto
{
    public string Name { get; set; } = null!;
}

public class UpdateRoleDto
{
    public string Name { get; set; } = null!;
}