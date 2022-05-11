using FluentValidation;

namespace CheckListService.Models;
public class AddItemModel
{
    public string? Content { get; set; }
    public decimal? Cost { get; set; }
    public int? CheckListId { get; set; }

}
public class AddItemModelValidator : AbstractValidator<AddItemModel>
{
    public AddItemModelValidator()
    {
        RuleFor(x => x.CheckListId).NotEmpty().WithMessage("CheckListId is required");
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).WithMessage("Cost should be positive or 0");
    }
}