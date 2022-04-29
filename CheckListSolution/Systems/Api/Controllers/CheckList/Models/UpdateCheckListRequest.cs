using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class UpdateCheckListRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int IdList { get; set; }
    public int IdUser { get; set; }

}

public class UpdateCheckListValidator : AbstractValidator<UpdateCheckListRequest>
{
    // CHANGED: add variable for number of symbols
    public UpdateCheckListValidator()
    {
        RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is  required (no more then 50 symbols)")
             .MaximumLength(50).WithMessage("Name is too long  (no more then 50 symbols)");

        RuleFor(x => x.Description)
            .MaximumLength(150).WithMessage("Description is too long (no more then 150 symbols)");

        RuleFor(x => x.IdList).NotEmpty().WithMessage("IdList is  required");

        RuleFor(x => x.IdUser).NotEmpty().WithMessage("IdUser is  required");
    }
}