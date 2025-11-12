using Solution.Core.Models;

namespace Solution.Services.Validators;

public class ItemModelValidator : AbstractValidator<ItemModel>
{
    public static string IdProperty => nameof(ItemModel.Id);
    public static string NameProperty => nameof(ItemModel.Name);
    public static string PriceProperty => nameof(ItemModel.Price);
    public static string AccountProperty => nameof(ItemModel.Account);
    public static string GlobalProperty => "Global";

    public ItemModelValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Item ID must be greater than 0!");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Item name must not be empty.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Item price must be non-negative.");

        RuleFor(x => x.Account)
            .NotNull().WithMessage("Account must not be null.");
    }
}
