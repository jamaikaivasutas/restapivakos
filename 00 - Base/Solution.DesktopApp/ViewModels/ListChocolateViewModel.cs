namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class ListChocolateViewModel(IChocolateService chocolateService)
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
    private ObservableCollection<ChocolateModel> chocolates;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfChocolatesInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => hasNextPage && !isLoading);
        await LoadChocolatesAsync();
    }

    private async Task OnDisappearingAsync()
    {
    }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;

        page = page <= 1 ? 1 : --page;
        await LoadChocolatesAsync();
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadChocolatesAsync();
    }

    private async Task LoadChocolatesAsync()
    {
        isLoading = true;

        var result = await chocolateService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Chocolates not loaded!", "OK");
            return;
        }

        Chocolates = new ObservableCollection<ChocolateModel>(result.Value.Items);
        numberOfChocolatesInDB = result.Value.Count;

        hasNextPage = numberOfChocolatesInDB - (page * 10) > 0;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnDeleteAsync(int id)
    {
        var result = await chocolateService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Chocolate deleted successfully!";
        var title = result.IsError ? "Error" : "Information"; 

        if(!result.IsError)
        {
            var chocolate = chocolates.SingleOrDefault(x =>x.Id == id);
            chocolates.Remove(chocolate);

            if (chocolates.Count == 0)
            {
                await LoadChocolatesAsync();
            }
        }
        
        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
