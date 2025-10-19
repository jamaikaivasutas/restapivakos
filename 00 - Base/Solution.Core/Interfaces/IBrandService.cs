using Solution.Core.Models;

namespace Solution.Core.Interfaces;

public interface IBrandService
{
    Task<ErrorOr<BrandModel>> CreateAsync(BrandModel model);
    Task<ErrorOr<Success>> UpdateAsync(BrandModel model);
    Task<ErrorOr<Success>> DeleteAsync(int id);
    Task<ErrorOr<BrandModel>> GetByIdAsync(int id);
    Task<ErrorOr<List<BrandModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<BrandModel>>> GetPagedAsync(int page = 0);
}
