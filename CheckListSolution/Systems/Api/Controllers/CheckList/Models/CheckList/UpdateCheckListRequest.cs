using Common;
using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class UpdateCheckListRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CheckListId { get; set; }
}

public class UpdateCheckListValidator : AbstractValidator<UpdateCheckListRequest>
{
    public UpdateCheckListValidator()
    {
        RuleFor(x => x.Name)
             .NotEmpty().WithMessage($"Name is  required (no more then {CommonConstants.MaxNameListLength} symbols)")
             .MaximumLength(CommonConstants.MaxNameListLength)
             .WithMessage($"Name is too long  (no more then {CommonConstants.MaxNameListLength} symbols)");

        RuleFor(x => x.Description)
            .MaximumLength(CommonConstants.MaxDescriptionListLength)
            .WithMessage($"Description is too long (no more then {CommonConstants.MaxDescriptionListLength} symbols)");

        RuleFor(x => x.CheckListId).NotEmpty().WithMessage("ListId is  required");
    }
}

