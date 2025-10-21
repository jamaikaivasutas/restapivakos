namespace Solution.Validators;

public class ChocolateModelValidator : BaseValidator<ChocolateModel>
{
    public static string FlavorProperty => nameof(ChocolateModel.Flavor);
    public static string PriceProperty => nameof(ChocolateModel.Price);
    public static string BrandProperty => nameof(ChocolateModel.Brand);

    public static string GlobalProperty => "Global";

    public ChocolateModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        if (IsPutMethod)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }

        RuleFor(x => x.Flavor)
            .NotEmpty()
            .WithMessage($"{FlavorProperty} is required.");

        RuleFor(x => x.Price)
            .NotNull()
            .WithMessage($"{PriceProperty} is required.")
            .GreaterThan(0)
            .WithMessage($"{PriceProperty} must be greater than 0.");

        RuleFor(x => x.Brand)
            .NotNull()
            .WithMessage($"{BrandProperty} is required.");

        RuleFor(x => x.Brand.Id)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage($"{BrandProperty} Id is required.");
    }
}
