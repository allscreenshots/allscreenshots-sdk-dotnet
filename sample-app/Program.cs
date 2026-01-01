using AllScreenshots.Sdk;
using AllScreenshots.Sdk.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add Allscreenshots client
builder.Services.AddAllScreenshots(options =>
{
    var apiKey = builder.Configuration["ALLSCREENSHOTS_API_KEY"]
        ?? Environment.GetEnvironmentVariable("ALLSCREENSHOTS_API_KEY");

    if (!string.IsNullOrEmpty(apiKey))
    {
        options.ApiKey = apiKey;
    }

    options.Timeout = TimeSpan.FromMinutes(2);
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
