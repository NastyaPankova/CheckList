using FluentValidation;

namespace Api.Controllers.CheckList.Models;
public class UpdateItemRequest
{
    public string? Content { get; set; }
    public decimal? Cost { get; set; } 
}
public class UpdateItemRequestValidator : AbstractValidator<UpdateItemRequest>
{
    public UpdateItemRequestValidator()
    {
        RuleFor(x => x.Cost).GreaterThanOrEqualTo(0).WithMessage("Cost should be positive or 0");
    }
}