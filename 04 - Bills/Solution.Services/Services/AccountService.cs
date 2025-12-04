

namespace Solution.Services.Services;

public class AccountService(AppDbContext dbContext) : IAccountService
{
    private const int ROW_COUNT = 20;
    
    //Need to find out whats unfinished with the services
    //Okay i have no idea what im doing!

    public async Task<ErrorOr<AccountModel>> CreateAsync(AccountModel model)
    {
        bool exists = await dbContext.Accounts.AnyAsync(x => x.AccountNumber == model.AccountNumber);

        if (exists)
        {
            return Error.Conflict(description: "Motorcycle already exists!");
        }

        var account = model.ToEntity();

        await dbContext.Accounts.AddAsync(account);
        await dbContext.SaveChangesAsync();

        return new AccountModel(account)
        {
            Items = model.Items
        };
    }

    public async Task<ErrorOr<Success>> UpdateAsync(AccountModel model)
    {
        var result = await dbContext.Accounts.AsNoTracking()
                                             .Where(x => x.AccountNumber == model.AccountNumber)
                                             .ExecuteUpdateAsync(x => x
                                                 .SetProperty(a => a.DateOfCreation, model.DateOfCreation)
                                                 .SetProperty(a => a.SumOfItemPrices, model.SumOfItemPrices)
                                             );
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string accountNumber)
    {
        var result = await dbContext.Accounts
                                    .AsNoTracking()
                                    .Include(x => x.Items)
                                    .Where(x => x.AccountNumber == accountNumber)
                                    .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<AccountModel>> GetByIdAsync(string accountNumber)
    {
        var account = await dbContext.Accounts
                                     .AsNoTracking()
                                     .Include(x => x.Items)
                                     .FirstOrDefaultAsync(x => x.AccountNumber == accountNumber);

        if (account is null)
        {
            return Error.NotFound(description: "Account not found");
        }

        return new AccountModel(account);
    }

    public async Task<ErrorOr<List<AccountModel>>> GetAllAsync() =>
        await dbContext.Accounts.AsNoTracking()
                                .Include(x => x.Items)
                                .Select(x => new AccountModel(x))
                                .ToListAsync();

    public async Task<ErrorOr<PaginationModel<AccountModel>>> GetPageAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var accounts = await dbContext.Accounts.AsNoTracking()
                                               .Include(x => x.Items)
                                               .Skip(page * ROW_COUNT)
                                               .Take(ROW_COUNT)
                                               .Select(x => new AccountModel(x))
                                               .ToListAsync();

        var paginationModel = new PaginationModel<AccountModel>
        {
            Items = accounts,
            Count = await dbContext.Accounts.CountAsync()
        };

        return paginationModel;
    }
}
