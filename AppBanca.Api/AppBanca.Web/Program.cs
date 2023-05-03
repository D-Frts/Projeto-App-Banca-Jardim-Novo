using AppBanca.Models.Domain;
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

builder.Services.AddScoped<IBancaService<Product>, ProductService>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var ApiBaseAddress = new Uri("https://localhost:7245");
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = ApiBaseAddress
});
var SyncFusion_Key = "Mgo+DSMBaFt+QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQlhjSn5SdkZhX3hadHI=;Mgo+DSMBPh8sVXJ1S0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtTdUViWXxcdnxVRGY=;ORg4AjUWIQA/Gnt2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5WdkZjWH9dcnJdR2da;MTkwMTc0OUAzMjMxMmUzMTJlMzMzNUxmYk5YdzhCb1ZlbUY0QzZ5T3V3VlJrZUduSnh5TVU2WVJwN25GcFZJNHM9;MTkwMTc1MEAzMjMxMmUzMTJlMzMzNUZJaEo5czVNZHdRdVVabEtPQVJZaDlwaTNvZjdCSjVjd1ZzYUd0WGdua3M9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Tc0VgWX5ec3ZTTmlcWA==;MTkwMTc1MkAzMjMxMmUzMTJlMzMzNWYzRWg1ODc5aVVyRVpzUUdFYVBSZjlqcE5lcU5JL3NzbFBxVFBGazZENTA9;MTkwMTc1M0AzMjMxMmUzMTJlMzMzNUF6dElvZ1lYSUFNandzaHNYUkNrdXRsMXZaTmdsUS92eExMMmFOSGZKTWs9;Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5WdkZjWH9dcnJcQGVV;MTkwMTc1NUAzMjMxMmUzMTJlMzMzNUd0aW8rNjBXYlhSZnZnL3NwaWRqeHpmc0tzaXBSbVg4empWSFVBLzRYbFk9;MTkwMTc1NkAzMjMxMmUzMTJlMzMzNVc4bUFESlE3U0Vxa3hpNDFwRS80RWFFRlNBVERaOEw3bTFaNmVZd3FVYjQ9;MTkwMTc1N0AzMjMxMmUzMTJlMzMzNWYzRWg1ODc5aVVyRVpzUUdFYVBSZjlqcE5lcU5JL3NzbFBxVFBGazZENTA9";
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncFusion_Key);

await builder.Build().RunAsync();
