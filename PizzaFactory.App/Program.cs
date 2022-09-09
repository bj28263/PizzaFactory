using PizzaFactory.App;
using PizzaFactory.App.Repositories;
using PizzaFactory.App.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<PizzaGenerator>();
builder.Services.AddScoped<IPizzaBaseRepository, PizzaBaseRepository>();
builder.Services.AddScoped<IPizzaToppingRepository, PizzaToppingRepository>();
builder.Services.Configure<PizzaConfig>(builder.Configuration.GetSection("PizzaConfig"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;


app.Run();
