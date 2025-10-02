using Solution.Services;

namespace Solution.DesktopApp.ViewModels;

public partial class CreateManufacturerViewModel(
    AppDbContext dbContext,
    IManufacturerService manufacturerService) : ManufacturerModel, IQueryAttributable
{
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
    public ICommand ValidateCommand => new Command<string>(OnValidateAsync);
    private ManufacturerModelValidator validator => new ManufacturerModelValidator();
    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    [ObservableProperty]
    private string title;

    private delegate Task ButtonActionDelagate();
    private ButtonActionDelagate asyncButtonAction;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {

        bool hasValue = query.TryGetValue("Manufacturer", out object result);

        if (!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            Title = "Add new manufacturer";
            return;
        }

        ManufacturerModel manufacturer = result as ManufacturerModel;

        this.Name = manufacturer.Name;
        this.Id = manufacturer.Id;


        asyncButtonAction = OnUpdateAsync;
        Title = "Update manufacturer";
    }
    private async void OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));
        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == ManufacturerModelValidator.GlobalProperty));

        ValidationResult.Errors.AddRange(result.Errors);

        OnPropertyChanged(nameof(propertyName));
    }
    private void ClearForm()
    {
        this.Name = null;
    }

    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Save failed", "OK");
            return;
        }

        var result = await manufacturerService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Manufacturer saved.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            ClearForm();
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnUpdateAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        var result = await manufacturerService.UpdateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Manufacturer updated.";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}