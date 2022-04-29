using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class AddCheckListRequest
{
    public string NameList { get; set; } = string.Empty;
    public string DescriptionList { get; set; } = string.Empty;

}

public class AddCheckListValidator : AbstractValidator<AddCheckListRequest>
{
    // CHANGED: add variable for number of symbols
    public AddCheckListValidator()
    {
        RuleFor(x => x.NameList)
            .NotEmpty().WithMessage("NameList is  required (no more then 50 symbols)")
            .MaximumLength(50).WithMessage("NameList is too long  (no more then 50 symbols)");

        RuleFor(x => x.DescriptionList)
            .MaximumLength(150).WithMessage("DescriptionList is too long (no more then 150 symbols)");
    }
}