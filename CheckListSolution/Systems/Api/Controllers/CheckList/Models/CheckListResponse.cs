using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class CheckListResponse
{
        public int IdList { get; set; }
        public string NameList { get; set; } = string.Empty;
        public string DescriptionList { get; set; } = string.Empty;
}

public class AddCheckListResponseValidator : AbstractValidator<CheckListResponse>
{
    // CHANGED: add variable for number of symbols
    public AddCheckListResponseValidator()
    {
        RuleFor(x => x.NameList)
            .NotEmpty().WithMessage("Enter CheckList name (no more then 40 symbols)")
            .MaximumLength(40).WithMessage("CheckList name is too long, it should be no more then 40 symbols");

        RuleFor(x => x.DescriptionList)
            .MaximumLength(150).WithMessage("Description is too long, it should be no more then 150 symbols");
    }
}