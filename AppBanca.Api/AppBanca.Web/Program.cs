using AppBanca.Models.Domain;
using AppBanca.Models.Dtos;
using AppBanca.Web;
using AppBanca.Web.Services;
using AppBanca.Web.Services.Intefaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSyncfusionBlazor();

builder.Services.AddScoped<IBancaService<ProductDto>, ProductDtoService>();
builder.Services.AddScoped<IBancaService<SupplierDto>, SupplierDtoService>();
builder.Services.AddScoped<IBancaService<CategoryDto>, CategoryDtoService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var ApiBaseAddress = new Uri("https://localhost:7245");
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = ApiBaseAddress
});

//var SyncFusion_Key = "MTkyNjU1MkAzMjMxMmUzMjJlMzNRU0ZENjdIQk9kZjN2M1J1T3RqTzRHQkRiL3dkamFtWTVYOWE3Y2JiaDhFPQ==";
//Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncFusion_Key);

await builder.Build().RunAsync();
