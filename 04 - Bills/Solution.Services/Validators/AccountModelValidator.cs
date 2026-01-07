using Solution.Core.Models;

namespace Solution.Services.Validators;

public class AccountModelValidator : BaseValidator<AccountModel>
{
    public static string AccNumProperty => nameof(AccountModel.AccountNumber);
    public static string DateOfCreationProperty => nameof(AccountModel.DateOfCreation);
    public static string SumOfItemPricesProperty => nameof(AccountModel.SumOfItemPrices);
    
    public static string GlobalProperty => "Global";

    public AccountModelValidator(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
        RuleFor(x => x.AccountNumber)
            .NotEmpty().WithMessage("Account number must not be empty.")
            .Matches(@"^[A-Z0-9]{24}$").WithMessage("Account number must be exactly 24 alphanumeric characters.");

        RuleFor(x => x.DateOfCreation)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Date of creation cannot be in the future.");

        RuleFor(x => x.SumOfItemPrices)
            .GreaterThanOrEqualTo(0).When(x => x.SumOfItemPrices.HasValue)
            .WithMessage("Sum of item prices must be non-negative if provided.");

    }
}

