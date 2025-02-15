using FluentValidation;
using Sevkiyat.Takip.Application.Models.OperationClaims;

namespace Sevkiyat.Takip.Application.Validators.OperationClaims;
public class CreateOperationClaimValidator: AbstractValidator<CreateOperationClaimModel>
{
    public CreateOperationClaimValidator()
    {
        RuleFor(i=> i.Name).NotEmpty().NotNull().MinimumLength(3);
        RuleFor(i => i.RoleId).NotEmpty().NotNull();
    }
}
