using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class WaterService
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<WaterService> _logger;
        public const string ControllerName = "api/Water";

        public WaterService(HttpClient httpClient, SessionServices sessionServices, ILogger<WaterService> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<Water>> GetWater()
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Water>>(ControllerName);
                return res;
            }
            return new List<Water>();
        }
        public async Task<List<Water>> GetWater(int page)
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Water>>($"{ControllerName}?page={page}");
                return res;
            }
            return new List<Water>();
        }
        public async Task<List<Water>> GetByYear(int Year)
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Water>>($"{ControllerName}?Year={Year}");
                return res;
            }
            return new List<Water>();
        }
        public async Task<List<Water>> GetByMonth(int Year, int Month)
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Water>>($"{ControllerName}?Year={Year}&Month={Month}");
                return res;
            }
            return new List<Water>();
        }
        public async Task<List<Water>> GetByRental(string RentalId)
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Water>>($"{ControllerName}/Rental/{RentalId}");
                return res;
            }
            return new List<Water>();
        }
        public async Task<List<Water>> GetPaidList()
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Water>>($"{ControllerName}/Paid");
                return res;
            }
            return new List<Water>();
        }
        public async Task<List<Water>> GetUnPaidList()
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Water>>($"{ControllerName}/UnPaid");
                return res;
            }
            return new List<Water>();
        }
        public async Task<List<Water>?> GetAdvancedSearch(ElectricityAndWaterAdvancedSearchCriteria criteria)
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName, criteria);
                return await res.Content.ReadFromJsonAsync<List<Water>>();
            }
            return new List<Water>();
        }
        public async Task<Water> GetOne(int Year, int Month, string RentalId)
        {
            var havePermission = true;
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<Water>($"{ControllerName}?Year={Year}&Month={Month}&RentalId={RentalId}");
                return res;
            }
            return new Water();
        }
        public async Task<bool> Create(Water item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            if (!res.IsSuccessStatusCode) return false;
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Update(Water item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            if (!res.IsSuccessStatusCode) return false;
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(Water item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", item);
            if (!res.IsSuccessStatusCode) return false;
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public Water Calculate(Water item,out decimal? Usage)
        {
            Usage = item.CurrentUnit - item.BeforeUnit;
            item.Total = item.Price * (Usage??0);
            return item;
        }
    }
}
