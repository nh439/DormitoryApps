using Microsoft.AspNetCore.ResponseCompression;
using dormitoryApps.Server.Databases;
using dormitoryApps.Server.Repository;
using dormitoryApps.Server.Services;
using dormitoryApps.Server.Securites;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<DBConnection>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSession();
builder.Services.AddScoped<PermissionService>();

#region Repository
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<OfficerRepository>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<DistrictsRepository>();
builder.Services.AddScoped<BuildingsRepository>();
builder.Services.AddScoped<CurrentCustomerRepository>();
builder.Services.AddScoped<SessionRepository>();
builder.Services.AddScoped<CustomerImgRepository>();
builder.Services.AddScoped<ElectricityRepository>();
builder.Services.AddScoped<WaterRepository>();
builder.Services.AddScoped<InvoiceRepository>();
builder.Services.AddScoped<PastCustomerRepository>();
#endregion

#region Services
builder.Services.AddScoped<IDepartmentServices, DepartmentService>();
builder.Services.AddScoped<IOfficerServices,OfficerServices>();
builder.Services.AddScoped<IAddressServices,AddressServices>();
builder.Services.AddScoped<IDistrictsServices, DistrictsServices>();
builder.Services.AddScoped<IBuildingsServices, BuildingsServices>();
builder.Services.AddScoped<ICurrentCustomerServices, CurrentCustomerServices>();
builder.Services.AddScoped<ISessionServices, SessionServices>();
builder.Services.AddScoped<ICustomerImgServices, CustomerImgServices>();
builder.Services.AddScoped<IElectricityServices, ElectricityServices>();
builder.Services.AddScoped<IWaterServices, WaterServices>();
builder.Services.AddScoped<IInvoiceServices, InvoiceServices>();   
builder.Services.AddScoped<IPastCustomerServices, PastCustomerServices>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
