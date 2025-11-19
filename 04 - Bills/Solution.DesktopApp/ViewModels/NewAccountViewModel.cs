namespace Solution.DesktopApp.ViewModels;

public partial class NewAccountViewModel(AppDbContext dbContext, IAccountService accountService, IItemService itemService) : AccountModel
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    private async Task OnAppearingAsync()
    {

    }

    private async Task OnDisappearingAsync()
    {

    }
}
