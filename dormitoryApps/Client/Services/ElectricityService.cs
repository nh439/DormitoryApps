using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class ElectricityService
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<ElectricityService> _logger;
        public const string ControllerName = "api/Electricity";

        public ElectricityService(HttpClient httpClient, 
            ILogger<ElectricityService> logger,
            SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices; 
        }
        public async Task<List<Electricity>> GetElectricity()
        {
            var havePermission = await  _sessionServices.Permissioncheck();
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Electricity>>(ControllerName);
                return res;
            }
            return new List<Electricity>();
        }
        public async Task<List<Electricity>> GetByYear(int Year)
        {
            var havePermission = await _sessionServices.Permissioncheck();
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Electricity>>($"{ControllerName}?Year={Year}");
                return res;
            }
            return new List<Electricity>();
        }
        public async Task<List<Electricity>> GetByMonth(int Year,int Month)
        {
            var havePermission = await _sessionServices.Permissioncheck();
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Electricity>>($"{ControllerName}?Year={Year}&Month={Month}");
                return res;
            }
            return new List<Electricity>();
        }
          public async Task<Electricity> GetOne(int Year,int Month,string RentalId)
        {
            var havePermission = await _sessionServices.Permissioncheck();
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<Electricity>($"{ControllerName}?Year={Year}&Month={Month}&RentalId={RentalId}");
                return res;
            }
            return new Electricity();
        }
        



    }
}
