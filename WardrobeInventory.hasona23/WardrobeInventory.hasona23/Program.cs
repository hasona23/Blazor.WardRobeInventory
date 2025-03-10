using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;
using WardrobeInventory.hasona23.Components;
using WardrobeInventory.hasona23.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<WardrobeDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WardrobeDbContext") ?? throw new InvalidOperationException("Connection string 'WardrobeDbContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<WardrobeDbContext>().Database;
    db.Migrate();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
