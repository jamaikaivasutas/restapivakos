
namespace Solution.Core.Models;

public partial class AccountModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("accountNumber")]
    private string accountNumber;

    [ObservableProperty]
    [JsonPropertyName("dateOfCreation")]
    private DateTime dateOfCreation;

    [ObservableProperty]
    [JsonPropertyName("sumOfItemPrices")]
    private int? sumOfItemPrices;

    public AccountModel()
    {
        
    }

    public AccountModel(AccountEntity entity) : this()
    {
        this.AccountNumber = entity.AccountNumber;
        this.DateOfCreation = entity.DateOfCreation;
        this.SumOfItemPrices = entity.SumOfItemPrices;
    }

    public AccountEntity ToEntity()
    {
        return new AccountEntity
        {
            AccountNumber = AccountNumber,
            DateOfCreation = DateOfCreation.Date,
            SumOfItemPrices = SumOfItemPrices.Value,
        };
    }

    public void ToEntity(AccountEntity entity)
    {
        entity.AccountNumber = AccountNumber;
        entity.DateOfCreation = DateOfCreation.Date;
        entity.SumOfItemPrices = SumOfItemPrices.Value;
    }
}
