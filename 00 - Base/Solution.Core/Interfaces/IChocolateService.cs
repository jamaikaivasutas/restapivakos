using Solution.Core.Models;

namespace Solution.Core.Interfaces;

public interface IChocolateService
{
    Task<ErrorOr<ChocolateModel>> CreateAsync(ChocolateModel model);
    Task<ErrorOr<Success>> UpdateAsync(ChocolateModel model);
    Task<ErrorOr<Success>> DeleteAsync(int id);
    Task<ErrorOr<ChocolateModel>> GetByIdAsync(int id);
    Task<ErrorOr<List<ChocolateModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<ChocolateModel>>> GetPagedAsync(int page = 0);
}
