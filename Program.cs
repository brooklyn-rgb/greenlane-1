// Program.cs - Minimal Azure deployment version
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// File upload limits
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 50 * 1024 * 1024;
});

// Health checks for Azure
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

// Health endpoint for Azure
app.MapHealthChecks("/health");
app.MapGet("/api/status", () => Results.Json(new
{
    status = "online",
    timestamp = DateTime.UtcNow,
    service = "Greenlane College Registration"
}));

app.MapRazorPages();

app.Run();