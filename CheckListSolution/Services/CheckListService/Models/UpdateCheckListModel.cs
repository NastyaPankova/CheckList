using AutoMapper;
using Common;
using DbEntities;
using FluentValidation;

namespace CheckListService;
public class UpdateCheckListModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CheckListId { get; set; }
    public Guid UserId { get; set; }

}

public class UpdateCheckListModelValidator : AbstractValidator<UpdateCheckListModel>
{
    public UpdateCheckListModelValidator()
    {
        RuleFor(x => x.Name)
             .NotEmpty().WithMessage($"Name is  required (no more then {CommonConstants.MaxNameListLength} symbols)")
             .MaximumLength(CommonConstants.MaxNameListLength)
             .WithMessage($"Name is too long  (no more then {CommonConstants.MaxNameListLength} symbols)");

        RuleFor(x => x.Description)
            .MaximumLength(CommonConstants.MaxDescriptionListLength)
            .WithMessage($"Description is too long (no more then {CommonConstants.MaxDescriptionListLength} symbols)");

        RuleFor(x => x.CheckListId).NotEmpty().WithMessage("ListId is  required");

        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is  required");
    }
}
public class UpdateCheckListModelProfile : Profile
{
    public UpdateCheckListModelProfile()
    {
        CreateMap<UpdateCheckListModelProfile, CheckList>();
    }
}
