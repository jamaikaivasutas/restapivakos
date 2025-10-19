namespace Solution.Services;

public class BrandService(AppDbContext dbContext) : IBrandService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<BrandModel>> CreateAsync(BrandModel model)
    {
        bool exists = await dbContext.Brands.AnyAsync(x => x.Name == model.Name);

        if (exists)
        {
            return Error.Conflict(description: "Brand already exists!");
        }
        var brand = model.ToEntity();

        await dbContext.Brands.AddAsync(brand);
        await dbContext.SaveChangesAsync();

        return new BrandModel(brand);
    }

    public async Task<ErrorOr<List<BrandModel>>> GetAllAsync() =>
        await dbContext.Brands
                       .AsNoTracking()
                       .Select(x => new BrandModel(x))
                       .ToListAsync();

    public async Task<ErrorOr<BrandModel>> GetByIdAsync(int id)
    {
        var brand = await dbContext.Brands
                                   .FirstOrDefaultAsync(x => x.Id == id);

        if (brand is null)
        {
            return Error.NotFound(description: "Brand not found!");
        }

        return new BrandModel(brand);
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var result = await dbContext.Brands.AsNoTracking()
                                           .Where(x => x.Id == id)
                                           .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> UpdateAsync(BrandModel model)
    {
        var result = await dbContext.Brands.AsNoTracking()
                                           .Where(x => x.Id == model.Id)
                                           .ExecuteUpdateAsync(x => x.SetProperty(p => p.Name, model.Name));

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<PaginationModel<BrandModel>>> GetPagedAsync(int page = 0)
    {
        page = page < 0 ? 1 : page - 1;

        var brands = await dbContext.Brands
                                .AsNoTracking()
                                .Skip(page * ROW_COUNT)
                                .Take(ROW_COUNT)
                                .Select(x => new BrandModel(x))
                                .ToListAsync();

        var paginationModel = new PaginationModel<BrandModel>
        {
            Items = brands,
            Count = await dbContext.Brands.CountAsync()
        };

        return paginationModel;
    }
}
