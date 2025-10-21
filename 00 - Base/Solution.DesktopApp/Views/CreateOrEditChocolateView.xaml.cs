namespace Solution.DesktopApp.Views;

public partial class CreateOrEditChocolateView : ContentPage
{
	public CreateOrEditChocolateViewModel ViewModel => this.BindingContext as CreateOrEditChocolateViewModel;
	public static string? Name => nameof(CreateOrEditChocolateView);
	public CreateOrEditChocolateView(CreateOrEditChocolateViewModel viewModel)
	{
		this.BindingContext = viewModel;

        InitializeComponent();
	}
}