namespace Solution.Core.Interfaces;

public interface IAccountService
{
    Task<ErrorOr<AccountModel>> CreateAsync(AccountModel model);
    Task<ErrorOr<Success>> UpdateAsync(AccountModel model);
    Task<ErrorOr<Success>> DeleteAsync(string accountNumber);
    Task<ErrorOr<AccountModel>> GetByIdAsync(string accountNumber);
    Task<ErrorOr<List<AccountModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<AccountModel>>> GetPageAsync(int page);
}
