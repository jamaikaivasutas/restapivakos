namespace Solution.Core.Models;

public partial class ItemModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    [ObservableProperty]
    [JsonPropertyName("price")]
    private int price;

    [ObservableProperty]
    [JsonPropertyName("account")]
    private AccountModel account;
    public ItemModel()
    {
        
    }
    public ItemModel(ItemEntity entity) : this()
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
        this.Price = entity.Price;
        this.Account = new AccountModel(entity.Account);
    }
    public ItemEntity ToEntity()
    {
        return new ItemEntity
        {
            Id = Id,
            Name = Name,
            Price = Price,
            AccountId = Account.AccountNumber,
        };
    }
    public void ToEntity(ItemEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
        entity.Price = Price;
        entity.AccountId = Account.AccountNumber;
    }
}
