using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class AddItemRequest
{
    public string? Content { get; set; }
    public decimal? Cost { get; set; }
    public int? CheckListId { get; set; }

}
public class AddItemRequestValidator : AbstractValidator<AddItemRequest>
{
    public AddItemRequestValidator()
    {
        RuleFor(x => x.CheckListId).NotEmpty().WithMessage("CheckListId is required");
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).WithMessage("Cost should be positive or 0");
    }
}