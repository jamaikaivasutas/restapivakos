namespace Solution.Validators;

public class BrandModelValidator : AbstractValidator<BrandModel>
{
    public static string NameProperty => nameof(BrandModel.Name);
    public static string GlobalProperty => "Global";

    public BrandModelValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage($"Brand name is required");
    }
}

