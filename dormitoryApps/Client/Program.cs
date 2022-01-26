using CurrieTechnologies.Razor.SweetAlert2;
using dormitoryApps.Client;
using dormitoryApps.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DepartmentServices>();
builder.Services.AddScoped<OfficerServices>();



await builder.Build().RunAsync();
