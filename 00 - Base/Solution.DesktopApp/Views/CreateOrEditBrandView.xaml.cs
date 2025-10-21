namespace Solution.DesktopApp.Views;

public partial class CreateOrEditBrandView : ContentPage
{
	public CreateOrEditBrandViewModel ViewModel => this.BindingContext as CreateOrEditBrandViewModel;
	public static string Name => nameof(CreateOrEditBrandView);

    public CreateOrEditBrandView(CreateOrEditBrandViewModel viewModel)
	{
        this.BindingContext = viewModel;

        InitializeComponent();
	}
}