namespace Solution.DesktopApp.ViewModels;

public partial class CreateOrEditChocolateViewModel(AppDbContext dbContext, IChocolateService chocolateService) : ChocolateModel, IQueryAttributable
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region validation
    public IRelayCommand ValidateCommand => new AsyncRelayCommand<string>(OnValidateAsync);
    #endregion

    #region event commands
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
    #endregion

    private ChocolateModelValidator validator => new ChocolateModelValidator(null);

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    private delegate Task ButtonActionDelegate();
    private ButtonActionDelegate asyncButtonAction;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private IList<BrandModel> brands = [];

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        bool hasValue = query.TryGetValue("Chocolate", out object result);
        if (!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            Title = "Create Chocolate";
            return;
        }

        ChocolateModel chocolate = result as ChocolateModel;

        this.Id = chocolate.Id;
        this.Flavor = chocolate.Flavor;
        this.Price = chocolate.Price;
        this.Brand = chocolate.Brand;

        asyncButtonAction = OnUpdateAsync;
        Title = "Update Chocolate";
    }

    private async Task OnAppearingAsync()
    {
    }

    private async Task OnDisappearingAsync()
    {
    }

    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        var result = await chocolateService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Chocolate created successfully";
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

        var result = await chocolateService.UpdateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Chocolate updated successfully";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task LoadBrandsAsync()
    {
        Brands = await dbContext.Brands.AsNoTracking()
                                       .OrderBy(x => x.Name)
                                       .Select(x => new BrandModel(x))
                                       .ToListAsync();
    }

    private void ClearForm()
    {
        this.Brand = new BrandModel();
        this.Flavor = null;
        this.Price = 0;
    }

    private async Task OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == ChocolateModelValidator.GlobalProperty));
        ValidationResult.Errors.AddRange(result.Errors);
        OnPropertyChanged(nameof(ValidationResult));
    }   
}