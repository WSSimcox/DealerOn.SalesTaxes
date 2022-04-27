using SalesTaxes.Data;
using SalesTaxes.Models;
using SalesTaxes.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IProductRepository productRepository = new ProductInMemoryRepository();

var salesCalc = new SalesTaxCalculatorServices(new ProductTaxRepository());
var importCalc = new ImportTaxCalculatorServices();

ITaxCalculatorServices[] calcArray = new ITaxCalculatorServices[2];
calcArray[0] = salesCalc;
calcArray[1] = importCalc;

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IProductRepository>(productRepository);
builder.Services.AddSingleton<IProductTaxRepository>(new ProductTaxRepository());
builder.Services.AddScoped<ITaxCalculatorServices>(builder => new ImportTaxCalculatorServices());
builder.Services.AddScoped<ITaxCalculatorServices>(builder => new SalesTaxCalculatorServices(new ProductTaxRepository()));
builder.Services.AddSingleton<ITransactionServices>(new TransactionServices(new ProductInMemoryRepository(), calcArray));
builder.Services.AddSingleton<IProductServices>(new ProductServices(productRepository));

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44401")) ;

// Adding basic starter products
productRepository.DefaultProductFiller();

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

//app.MapFallbackToFile("index.html"); ;

app.Run();
