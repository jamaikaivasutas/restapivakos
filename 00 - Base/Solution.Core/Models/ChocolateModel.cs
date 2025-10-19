

namespace Solution.Core.Models;

public partial class ChocolateModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("flavor")]
    private string flavor;

    [ObservableProperty]
    [JsonPropertyName("price")]
    private int? price;

    [ObservableProperty]
    [JsonPropertyName("brand")]
    private BrandModel brand;

    public ChocolateModel()
    {
        
    }

    public ChocolateModel(ChocolateEntity entity) : this()
    {
        this.Id = entity.Id;
        this.Flavor = entity.Flavor;
        this.Price = entity.Price;
        this.Brand = new BrandModel(entity.Brand);
    }

    public ChocolateEntity ToEntity()
    {
        return new ChocolateEntity
        {
            Id = Id,
            BrandId = Brand.Id,
            Flavor = Flavor,
            Price = Price.Value,
        };
    }

    public void ToEntity(ChocolateEntity entity)
    {
        entity.Id = Id;
        entity.Flavor = Flavor;
        entity.Price = Price.Value;
        entity.BrandId = Brand.Id;
    }
}
