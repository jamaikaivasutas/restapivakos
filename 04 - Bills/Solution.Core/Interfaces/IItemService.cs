namespace Solution.Core.Interfaces;

public interface IItemService
{
    Task<ErrorOr<ItemModel>> CreateAsync(ItemModel model);
    Task<ErrorOr<Success>> UpdateAsync(ItemModel model);
    Task<ErrorOr<Success>> DeleteAsync(int id);
    Task<ErrorOr<ItemModel>> GetByIdAsync(int id);
    Task<ErrorOr<List<ItemModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<ItemModel>>> GetPageAsync(int page);
}
