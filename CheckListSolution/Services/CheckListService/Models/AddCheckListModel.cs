using AutoMapper;
using Common;
using DbEntities;
using FluentValidation;


namespace CheckListService.Models;
public class AddCheckListModel
{ 
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int UserId { get; set; }

}

public class AddCheckListModelValidator : AbstractValidator<AddCheckListModel>
{
    public AddCheckListModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage($"Name is  required (no more then {CommonConstants.MaxNameListLength} symbols)")
            .MaximumLength(CommonConstants.MaxNameListLength).WithMessage($"Name is too long  (no more then {CommonConstants.MaxNameListLength} symbols)");

        RuleFor(x => x.Description)
            .MaximumLength(CommonConstants.MaxDescriptionListLength).WithMessage($"Description is too long (no more then {CommonConstants.MaxDescriptionListLength} symbols)");

        RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");
    }
}

public class AddCheckListModelProfile : Profile
{
    public AddCheckListModelProfile()
    {
        CreateMap<AddCheckListModel, CheckList>();
    }
}
