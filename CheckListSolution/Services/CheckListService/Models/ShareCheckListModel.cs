using AutoMapper;
using DbEntities;
using FluentValidation;

namespace CheckListService;
public class ShareCheckListModel
{
    public int UserId { get; set; }
    public int RecipientId { get; set; }
    public int CheckListId { get; set; }

}

public class ShareCheckListModelValidator : AbstractValidator<ShareCheckListModel>
{
      public ShareCheckListModelValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is  required");
        RuleFor(x => x.RecipientId).NotEmpty().WithMessage("RecipientId is  required");
        RuleFor(x => x.CheckListId).NotEmpty().WithMessage("ListId is  required");

    }
}

public class ShareCheckListModelProfile : Profile
{
    public ShareCheckListModelProfile()
    {
        CreateMap<ShareCheckListModelProfile, CheckList>();
    }
}
