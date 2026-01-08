var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.ConfigureDatabase()
       .LoadSettings()
       .UseSecurity()
       .UseIdentity()
       .ConfigureDI()
       .LoadEnvironmentVariables();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.UseSecurity();
app.MapControllers();

await app.RunAsync();
