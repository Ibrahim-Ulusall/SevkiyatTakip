namespace Sevkiyat.Takip.Application.Models.OperationClaims;
public class CreateOperationClaimModel
{
    public string Name { get; set; } = null!;
    public int RoleId { get; set; }
    public CreateOperationClaimModel() { }

    public CreateOperationClaimModel(string name, int roleId)
    {
        Name = name;
        RoleId = roleId;
    }
}
