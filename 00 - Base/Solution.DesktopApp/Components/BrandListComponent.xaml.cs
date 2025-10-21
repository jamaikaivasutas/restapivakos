namespace Solution.DesktopApp.Components;

public partial class BrandListComponent : ContentView
{
    public static readonly BindableProperty BrandProperty = BindableProperty.Create(
         propertyName: nameof(Brand),
         returnType: typeof(BrandModel),
         declaringType: typeof(BrandListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public BrandModel Brand
    {
        get => (BrandModel)GetValue(BrandProperty);
        set => SetValue(BrandProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
         propertyName: nameof(DeleteCommand),
         returnType: typeof(IAsyncRelayCommand),
         declaringType: typeof(BrandListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public IAsyncRelayCommand DeleteCommand
    {
        get => (IAsyncRelayCommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
         propertyName: nameof(CommandParameter),
         returnType: typeof(string),
         declaringType: typeof(BrandListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public BrandListComponent()
    {
        InitializeComponent();
    }

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Brand", this.Brand}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditBrandView.Name, navigationQueryParameter);
    }
}