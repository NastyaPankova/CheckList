using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class ShareCheckListRequest
{
    public int IdUser { get; set; }
    public int IdRecipient { get; set; }
    public int IdList { get; set; }

}

public class ShareCheckListValidator : AbstractValidator<ShareCheckListRequest>
{
    // CHANGED: add variable for number of symbols
    public ShareCheckListValidator()
    {
        RuleFor(x => x.IdUser).NotEmpty().WithMessage("IdUser is  required");
        RuleFor(x => x.IdRecipient).NotEmpty().WithMessage("IdRecipient is  required");
        RuleFor(x => x.IdList).NotEmpty().WithMessage("IdList is  required");

    }
}
