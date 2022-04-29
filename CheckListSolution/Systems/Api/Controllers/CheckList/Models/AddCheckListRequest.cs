using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class AddCheckListRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int IdUser { get; set; }

}

public class AddCheckListValidator : AbstractValidator<AddCheckListRequest>
{
    // CHANGED: add variable for number of symbols
    public AddCheckListValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is  required (no more then 50 symbols)")
            .MaximumLength(50).WithMessage("Name is too long  (no more then 50 symbols)");

        RuleFor(x => x.Description)
            .MaximumLength(150).WithMessage("Description is too long (no more then 150 symbols)");

        RuleFor(x => x.IdUser).NotEmpty().WithMessage("IdUser is required");
    }
}