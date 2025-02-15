using FluentValidation;
using Sevkiyat.Takip.Application.Models.Roles;

namespace Sevkiyat.Takip.Application.Validators.Roles;
public class CreateRoleValidator: AbstractValidator<CreateRoleModel>
{
    public CreateRoleValidator()
    {
        RuleFor(i => i.Name).NotEmpty().NotNull().MinimumLength(3);
    }
}
