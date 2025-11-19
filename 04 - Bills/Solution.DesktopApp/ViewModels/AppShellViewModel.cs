namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);
    public IAsyncRelayCommand AddNewAccountCommand => new AsyncRelayCommand(OnAddNewAccountAsync);
    public IAsyncRelayCommand ListAccountsCommand => new AsyncRelayCommand(OnListAccountsAsync);

    private async Task OnExitAsync() => Application.Current.Quit();

    private async Task OnAddNewAccountAsync()
    {
        Shell.Current.ClearNavigationStack();
        //View not yet done, neither is the viewmodel
        await Shell.Current.GoToAsync(nameof(NewAccountView.Name));
    }

    private async Task OnListAccountsAsync()
    {
        //Not yet finished
    }
}
