namespace Solution.Services;

public class ChocolateService(AppDbContext dbContext) : IChocolateService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<ChocolateModel>> CreateAsync(ChocolateModel model)
    {
        bool exists = await dbContext.Chocolates.AnyAsync(x => x.BrandId == model.Brand.Id);

        if (exists)
        {
            return Error.Conflict(description: "Chocolate already exists!");
        }

        var chocolate = model.ToEntity();

        await dbContext.Chocolates.AddAsync(chocolate);
        await dbContext.SaveChangesAsync();

        return new ChocolateModel(chocolate)
        {
            Brand = model.Brand
        };
    }

    public async Task<ErrorOr<Success>> UpdateAsync(ChocolateModel model)
    {
        var result = await dbContext.Chocolates.AsNoTracking()
                                               .Where(x => x.Id == model.Id)
                                               .ExecuteUpdateAsync(x => x.SetProperty(p => p.Flavor, model.Flavor)
                                                                        .SetProperty(p => p.Price, model.Price.Value)
                                                                        .SetProperty(p => p.BrandId, model.Brand.Id));
        return result > 0 ? Result.Success : Error.NotFound();
    }


    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var result = await dbContext.Chocolates.AsNoTracking()
                                               .Include(x => x.Brand)
                                               .Where(x => x.Id == id)
                                               .ExecuteDeleteAsync();
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<ChocolateModel>> GetByIdAsync(int id)
    {
        var chocolate = await dbContext.Chocolates.Include(x => x.Brand)
                                                  .FirstOrDefaultAsync(x => x.Id == id);

        if (chocolate is null)
        {
            return Error.NotFound(description: "Chocolate not found!");
        }

        return new ChocolateModel(chocolate);
    }

    public async Task<ErrorOr<List<ChocolateModel>>> GetAllAsync() =>
        await dbContext.Chocolates.AsNoTracking()
                                  .Include(x => x.Brand)
                                  .Select(x => new ChocolateModel(x))
                                  .ToListAsync();

    public async Task<ErrorOr<PaginationModel<ChocolateModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var chocolates = await dbContext.Chocolates.AsNoTracking()
                                                   .Include(x => x.Brand)
                                                   .Skip(page * ROW_COUNT)
                                                   .Take(ROW_COUNT)
                                                   .Select(x => new ChocolateModel(x))
                                                   .ToListAsync();
       var paginationModel = new PaginationModel<ChocolateModel>
       {
           Items = chocolates,
           Count = await dbContext.Chocolates.CountAsync()
       };

    return paginationModel;
    }

}