namespace Solution.DesktopApp.Views;

public partial class ListChocolateView : ContentPage
{
	public ListChocolateViewModel ViewModel => this.BindingContext as ListChocolateViewModel;
	public static string Name => nameof(ListChocolateView);

    public ListChocolateView(ListChocolateViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}