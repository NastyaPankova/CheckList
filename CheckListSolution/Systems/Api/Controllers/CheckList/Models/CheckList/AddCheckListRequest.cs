using AutoMapper;
using FluentValidation;
using CheckListService.Models;
using Common;

namespace Api.Controllers.CheckList.Models;
public class AddCheckListRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class AddCheckListValidator : AbstractValidator<AddCheckListRequest>
{
    public AddCheckListValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage($"Name is  required (no more then {CommonConstants.MaxNameListLength} symbols)")
            .MaximumLength(CommonConstants.MaxNameListLength)
            .WithMessage($"Name is too long  (no more then {CommonConstants.MaxNameListLength} symbols)");

        RuleFor(x => x.Description)
            .MaximumLength(CommonConstants.MaxDescriptionListLength)
            .WithMessage($"Description is too long (no more then {CommonConstants.MaxDescriptionListLength} symbols)");
    }
}
