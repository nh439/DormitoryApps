using CurrieTechnologies.Razor.SweetAlert2;
using dormitoryApps.Client;
using dormitoryApps.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Modal;
using Blazored.SessionStorage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddSweetAlert2();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredSessionStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<DepartmentServices>();
builder.Services.AddScoped<OfficerServices>();
builder.Services.AddScoped<DistrictServices>();
builder.Services.AddScoped<AddressServices>();
builder.Services.AddScoped<SessionServices>();
builder.Services.AddScoped<BuildingServices>();
builder.Services.AddScoped<CurrentCustomerService>();
builder.Services.AddScoped<ElectricityService>();
builder.Services.AddScoped<WaterService>();
builder.Services.AddScoped<InvoiceServices>();
builder.Services.AddScoped<PastCustomerServices>();
builder.Services.AddScoped<PostitionServices>();
builder.Services.AddScoped<PostitionLineService>();
builder.Services.AddScoped<RoomServices>();
builder.Services.AddScoped<RoomFurnServices>();
builder.Services.AddScoped<RoomImgServices>();

await builder.Build().RunAsync();
