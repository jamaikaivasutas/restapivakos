namespace Solution.DesktopApp.Views;

public partial class ListBrandView : ContentPage
{
	public ListBrandViewModel ViewModel => this.BindingContext as ListBrandViewModel;
	public static string Name => nameof(ListBrandView);

    public ListBrandView(ListBrandViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}