using dormitoryApps.Server.Databases;
using dormitoryApps.Server.Repository;
using dormitoryApps.Server.Services;
using dormitoryApps.Server.Securites;
using Hangfire;
using Hangfire.SQLite;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hangfire.Server;
using Hangfire.Client;
using Hangfire.Common;
using dormitoryApps.Server.Services.Job;
using dormitoryApps.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
var conString = configuration.GetConnectionString("Hangfire");

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<DBConnection>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSession();
builder.Services.AddScoped<PermissionService>();

builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
});

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
builder.Services.AddScoped<PostitionRepository>();
builder.Services.AddScoped<PostitionLineRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<RoomFurnRepository>();
builder.Services.AddScoped<RoomImgRepository>();
builder.Services.AddScoped<MyServiceRepository>();
builder.Services.AddScoped<InvoiceServiceRepository>();
builder.Services.AddScoped<PostitionChangedRepository>();
builder.Services.AddScoped<RoomFurnHeaderValuesRepository>();
builder.Services.AddScoped<RoomFurnHeaderRepository>();
builder.Services.AddScoped<RoomfurnTemplateRepository>();
builder.Services.AddScoped<RoomTemplateRepository>();
builder.Services.AddScoped<MemberRepository>();
builder.Services.AddScoped<RentalMemberRepository>();
builder.Services.AddScoped<RentalAccountRepository>();
builder.Services.AddScoped<BankRepository>();
builder.Services.AddScoped<ChangePasswordHistoryRepository>();
builder.Services.AddScoped<ForgotPasswordRepository>();
builder.Services.AddSingleton<NotificationAttendeeRepository>();
builder.Services.AddSingleton<NotificationAttachmentRepository>();
builder.Services.AddSingleton<NotificationRepository>();
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
builder.Services.AddScoped<IPostitionServices, PostitionServices>();
builder.Services.AddScoped<IPostitionLineServices, PostitionLineServices>();
builder.Services.AddScoped<IRoomServices, RoomServices>();
builder.Services.AddScoped<IRoomFurnServices,RoomFurnService>();
builder.Services.AddScoped<IRoomImgServices, RoomImgServices>();
builder.Services.AddScoped<IMyServicesServices, MyServicesServices>();
builder.Services.AddScoped<IIServices, iIService>();
builder.Services.AddScoped<IPostitionChangedService, PostitionChangedService>();
builder.Services.AddScoped<JwTServices>();
builder.Services.AddScoped<IRoomFurnHeaderValuesServices, RoomFurnHeaderValuesServices>();
builder.Services.AddScoped<IRoomFurnHeaderServices, RoomFurnHeaderServices>();
builder.Services.AddScoped<IRoomfurnTemplateServices,RoomfurnTemplateServices>();
builder.Services.AddScoped<IRoomTemplateServices,RoomTemplateServices>();
builder.Services.AddScoped<IMemberServices,MemberServices>();
builder.Services.AddScoped<IRentalMemberServices,RentalMemberServices>();
builder.Services.AddScoped<IRentalAccountServices,RentalAccountServices>();
builder.Services.AddScoped<IBankServices,BankServices>();
builder.Services.AddScoped<IChangePasswordHistoryService,ChangePasswordHistoryService>();
builder.Services.AddScoped<IForgotPasswordServices,ForgotPasswordServices>();
builder.Services.AddScoped<IEmailServices,EmailService>();
builder.Services.AddSingleton<INotificationAttendeeServices,NotificationAttendeeServices>();
builder.Services.AddSingleton<INotificationAttachmentServices,NotificationAttachmentService>();
builder.Services.AddSingleton<INotificationServices,NotificationServices>();
builder.Services.AddSingleton<IJobServices, JobServices>();
#endregion
builder.Services.AddHangfire(x => x.UseStorage(new Hangfire.SQLite.SQLiteStorage(conString, new Hangfire.SQLite.SQLiteStorageOptions())));
builder.Services.AddHangfireServer();

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
app.UseAuthentication();
app.UseSchedule();

app.Run();
