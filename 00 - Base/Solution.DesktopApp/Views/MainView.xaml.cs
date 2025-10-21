namespace Solution.DesktopApp;

public partial class MainView : ContentPage
{
    public MainPageViewModel ViewModel => this.BindingContext as MainPageViewModel;

    public static string Name => nameof(MainView);

    public MainView(MainPageViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }
}
