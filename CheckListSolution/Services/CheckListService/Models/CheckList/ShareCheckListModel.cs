using FluentValidation;

namespace CheckListService.Models;
public class ShareCheckListModel
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public int CheckListId { get; set; }

}

public class ShareCheckListModelValidator : AbstractValidator<ShareCheckListModel>
{
      public ShareCheckListModelValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.CheckListId).NotEmpty().WithMessage("CheckListId is required");

    }
}
