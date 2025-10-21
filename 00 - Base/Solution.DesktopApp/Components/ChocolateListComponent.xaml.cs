namespace Solution.DesktopApp.Components;

public partial class ChocolateListComponent : ContentView
{
    public static readonly BindableProperty ChocolateProperty = BindableProperty.Create(
         propertyName: nameof(Chocolate),
         returnType: typeof(ChocolateModel),
         declaringType: typeof(ChocolateListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public ChocolateModel Chocolate
    {
        get => (ChocolateModel)GetValue(ChocolateProperty);
        set => SetValue(ChocolateProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
         propertyName: nameof(DeleteCommand),
         returnType: typeof(IAsyncRelayCommand),
         declaringType: typeof(ChocolateListComponent),
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
         declaringType: typeof(ChocolateListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public ChocolateListComponent()
    {
        InitializeComponent();
    }

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Chocolate", this.Chocolate}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditChocolateView.Name, navigationQueryParameter);
    }
}