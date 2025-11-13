using Solution.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.LoadAppSettingsVariables()
       .ConfigureDI()
       .ConfigureDatabase()
       .ConfigureFluentValidation();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
