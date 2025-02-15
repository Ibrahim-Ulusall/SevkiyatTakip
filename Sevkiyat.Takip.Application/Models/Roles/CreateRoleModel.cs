namespace Sevkiyat.Takip.Application.Models.Roles;
public class CreateRoleModel
{
    public string Name { get; set; } = null!;
    public CreateRoleModel() { }
    public CreateRoleModel(string name)
    {
        Name = name;
    }
}
