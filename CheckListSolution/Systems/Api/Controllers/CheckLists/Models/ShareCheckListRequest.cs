using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class ShareCheckListRequest
{
    public int UserId { get; set; }
    public int RecipientId { get; set; }
    public int CheckListListId { get; set; }

}

public class ShareCheckListValidator : AbstractValidator<ShareCheckListRequest>
{
    public ShareCheckListValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is  required");
        RuleFor(x => x.RecipientId).NotEmpty().WithMessage("RecipientId is  required");
        RuleFor(x => x.CheckListListId).NotEmpty().WithMessage("CheckListListId is  required");

    }
}
