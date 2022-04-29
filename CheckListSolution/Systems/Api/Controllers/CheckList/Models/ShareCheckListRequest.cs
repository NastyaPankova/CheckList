using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class ShareCheckListRequest
{
    public string NameList { get; set; } = string.Empty;
    public string DescriptionList { get; set; } = string.Empty;
    public string RecipientEmail { get; set; } = string.Empty;

}

public class ShareCheckListValidator : AbstractValidator<ShareCheckListRequest>
{
    // CHANGED: add variable for number of symbols
    public ShareCheckListValidator()
    {
        RuleFor(x => x.NameList)
            .NotEmpty().WithMessage("NameList is  required (no more then 50 symbols)")
            .MaximumLength(50).WithMessage("NameList is too long  (no more then 50 symbols)");

        RuleFor(x => x.DescriptionList)
            .MaximumLength(150).WithMessage("DescriptionList is too long (no more then 150 symbols)");

        RuleFor(x => x.RecipientEmail).NotEmpty().WithMessage("RecipientEmail is  required");
    }
}