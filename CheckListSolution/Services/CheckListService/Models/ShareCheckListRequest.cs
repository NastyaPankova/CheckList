/*using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class ShareCheckListRequest
{
    public int UserId { get; set; }
    public int RecipientId { get; set; }
    public int CheckListListId { get; set; }

}

public class ShareCheckListValidator : AbstractValidator<ShareCheckListRequest>
{
    // CHANGED: add variable for number of symbols
    public ShareCheckListValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("IdUser is  required");
        RuleFor(x => x.RecipientId).NotEmpty().WithMessage("IdRecipient is  required");
        RuleFor(x => x.CheckListListId).NotEmpty().WithMessage("IdList is  required");

    }
}*/
