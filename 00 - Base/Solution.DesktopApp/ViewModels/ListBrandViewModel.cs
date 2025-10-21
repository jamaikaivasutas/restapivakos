using Windows.System.Profile.SystemManufacturers;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class ListBrandViewModel(IBrandService brandService)
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region paging commands
    public ICommand PreviousPageCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }
    #endregion

    #region component commands
    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<int>((id) => OnDeleteAsync(id));
    #endregion

    [ObservableProperty]
    private ObservableCollection<BrandModel> brands;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfBrandsInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => hasNextPage && !isLoading);

        await LoadBrandsAsync();
    }

    private async Task OnDisappearingAsync()
    {

    }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;
        page = page <= 1 ? 1 : --page;
        await LoadBrandsAsync();
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadBrandsAsync();
    }

    private async Task LoadBrandsAsync()
    {
        isLoading = true;

        var result = await brandService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Brands not loaded!", "OK");
            return;
        }

        Brands = new ObservableCollection<BrandModel>(result.Value.Items);
        numberOfBrandsInDB = result.Value.Count;

        hasNextPage = numberOfBrandsInDB - (page * 10) > 0;
        isLoading = false;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnDeleteAsync(int id)
    {
        var result = await brandService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description: "Brand deleted successfully!";
        var title = result.IsError ? "Error" : "Information";
        
        if (!result.IsError)
        {
            var brand = brands.FirstOrDefault(b => b.Id == id);
            brands.Remove(brand);

            if (brands.Count == 0)
            {
                await LoadBrandsAsync();
            }
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}

