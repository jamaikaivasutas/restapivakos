namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);

    public IAsyncRelayCommand AddNewChocolateCommand => new AsyncRelayCommand(OnAddNewChocolateAsync);

    public IAsyncRelayCommand AddNewBrandCommand => new AsyncRelayCommand(OnAddNewBrandAsync);

    public IAsyncRelayCommand ListAllChocolatesCommand => new AsyncRelayCommand(OnListAllChocolatesAsync);

    public IAsyncRelayCommand ListAllBrandsCommand => new AsyncRelayCommand(OnListAllBrandsAsync);

    private async Task OnExitAsync() => Application.Current.Quit();

    private async Task OnAddNewChocolateAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditChocolateView.Name);
    }

    private async Task OnListAllChocolatesAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(ListChocolateView.Name);
    }

    private async Task OnAddNewBrandAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditBrandView.Name);
    }

    private async Task OnListAllBrandsAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(ListBrandView.Name);
    }   
}
