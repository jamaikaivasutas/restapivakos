namespace Solution.DesktopApp.Converters;

internal class ValidationResultToErrorMessagesConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (value is not ValidationResult validationResult || validationResult.IsValid)
        {
            return null;
        }

        if (parameter == null)
        {
            return null;
        }

        var property = parameter as string;
        var errorMessages = validationResult.Errors.Where(e => e.PropertyName == property).Select(e => e.ErrorMessage);

        return string.Join(Environment.NewLine, errorMessages);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}