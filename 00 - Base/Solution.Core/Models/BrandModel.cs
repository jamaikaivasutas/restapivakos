namespace Solution.Core.Models;

public partial class BrandModel : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name;

    public BrandModel()
    {
        
    }

    public BrandModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public BrandModel(BrandEntity entity) : this()
    {
        if (entity is null)
        {
            return;
        }

        Id = entity.Id;
        Name = entity.Name;
    }
}
