namespace Solution.DesktopApp.ViewModels;

public partial class CreateOrEditBrandViewModel(AppDbContext dbContext, IBrandService brandService) : BrandModel, IQueryAttributable
{
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);

    public ICommand ValidateCommand => new Command<string>(OnValidateAsync);

    private BrandModelValidator validator => new BrandModelValidator();

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    [ObservableProperty]
    private string title;

    private delegate Task ButtonActionDelegate();
    private ButtonActionDelegate asyncButtonAction;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        bool hasValue = query.TryGetValue("Brand", out object result);

        if (!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            Title = "Create Brand";
            return;
        }

        BrandModel brand = result as BrandModel;

        this.Name = brand.Name;
        this.Id = brand.Id;

        asyncButtonAction = OnUpdateAsync;
        Title = "Update Brand";
    }

    private async void OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));
        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == BrandModelValidator.GlobalProperty));

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
            await Application.Current.MainPage.DisplayAlert("Validation Error", "Save failed", "Ok");
            return;
        }

        var result = await brandService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Brand created successfully";
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

        var result = await brandService.UpdateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Brand updated successfully";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
