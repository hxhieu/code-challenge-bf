using CodeChallengeBF.Infra.Middlewares;
using CodeChallengeBF.Service;
using CodeChallengeBF.Service.Contract;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddControllersWithViews();

// Custom dependencies
builder.Services.RegisterServices();

var app = builder.Build();

// Do some starting up
var testFormService = app.Services.GetService<ITestFormService>();
if (testFormService != null)
{
    // Load the cache from the JSON file
    await testFormService.InitCache();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}" );

app.MapFallbackToFile( "index.html" );

app.Run();
