using Microsoft.AspNetCore.ResponseCompression;
using dormitoryApps.Server.Databases;
using dormitoryApps.Server.Repository;
using dormitoryApps.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<DBConnection>();

#region Repository
builder.Services.AddScoped<DepartmentRepository>();
builder.Services.AddScoped<OfficerRepository>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<DistrictsRepository>();
#endregion

#region Services
builder.Services.AddScoped<IDepartmentServices, DepartmentService>();
builder.Services.AddScoped<IOfficerServices,OfficerServices>();
builder.Services.AddScoped<IAddressServices,AddressServices>();
builder.Services.AddScoped<IDistrictsServices, DistrictsServices>();
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


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
