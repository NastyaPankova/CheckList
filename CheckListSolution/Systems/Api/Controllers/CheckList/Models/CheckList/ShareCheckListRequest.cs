using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class ShareCheckListRequest
{
    public string Email { get; set; }
    public int CheckListId { get; set; }

}

public class ShareCheckListValidator : AbstractValidator<ShareCheckListRequest>
{
    public ShareCheckListValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.CheckListId).NotEmpty().WithMessage("CheckListId is required");

    }
}