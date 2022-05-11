using DbEntities;
using FluentValidation;

namespace CheckListService.Models;
public class UpdateItemModel
{
    public int? ListItemId { get; set; }
    public string? Content { get; set; }
    public decimal? Cost { get; set; } 
}
public class UpdateItemModelValidator : AbstractValidator<UpdateItemModel>
{
    public UpdateItemModelValidator()
    {
        RuleFor(x => x.ListItemId).NotEmpty().WithMessage("ListItemId is  required");
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).WithMessage("Cost should be positive or 0");
    }
}