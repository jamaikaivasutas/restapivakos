
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

    [ObservableProperty]
    [JsonPropertyName("item")]
    private ItemModel item;

    public AccountModel()
    {
        
    }

    public AccountModel(AccountEntity entity) : this()
    {
        this.AccountNumber = entity.AccountNumber;
        this.DateOfCreation = entity.DateOfCreation;
        this.SumOfItemPrices = entity.SumOfItemPrices;
        this.Item = new ItemModel(entity.Item);
    }

    public AccountEntity ToEntity()
    {
        return new AccountEntity
        {
            AccountNumber = AccountNumber,
            DateOfCreation = DateOfCreation.Date,
            SumOfItemPrices = SumOfItemPrices.Value,
            ItemId = Item.Id,
        };
    }

    public void ToEntity(AccountEntity entity)
    {
        entity.AccountNumber = AccountNumber;
        entity.DateOfCreation = DateOfCreation.Date;
        entity.SumOfItemPrices = SumOfItemPrices.Value;
        entity.ItemId = Item.Id;
    }
}
