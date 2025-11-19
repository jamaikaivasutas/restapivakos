namespace Solution.DesktopApp.Views;

public partial class NewAccountView : ContentPage
{
	public NewAccountViewModel ViewModel => this.BindingContext as NewAccountViewModel;

	public static string Name => nameof(NewAccountView);
	public NewAccountView(NewAccountViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}