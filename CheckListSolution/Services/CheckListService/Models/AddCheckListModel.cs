using FluentValidation;


namespace CheckListService.Models;
public class AddCheckListModel
{ 
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }

}

public class AddCheckListModelValidator : AbstractValidator<AddCheckListModel>
{
    // CHANGED: add variable for number of symbols
    public AddCheckListModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is  required (no more then 50 symbols)")
            .MaximumLength(50).WithMessage("Name is too long  (no more then 50 symbols)");

        RuleFor(x => x.Description)
            .MaximumLength(150).WithMessage("Description is too long (no more then 150 symbols)");

        RuleFor(x => x.UserId).NotEmpty().WithMessage("IdUser is required");
    }
}
