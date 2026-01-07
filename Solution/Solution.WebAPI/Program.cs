using Solution.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.ConfigureDatabase()
       .LoadEnvironmentVariables();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

await app.RunAsync();
