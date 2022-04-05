using DealerOn.SalesTaxes.Data;
using DealerOn.SalesTaxes.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IProductRepository>();
builder.Services.AddSingleton<IProductTaxRepository>();
builder.Services.AddSingleton<ITaxCalculatorServices>(builder => new ImportTaxCalculatorServices());
builder.Services.AddScoped<ITaxCalculatorServices>(builder => new SalesTaxCalculatorServices(new ProductTaxRepository()));
builder.Services.AddSingleton<ITransactionServices>();
builder.Services.AddSingleton<IProductServices>();


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
