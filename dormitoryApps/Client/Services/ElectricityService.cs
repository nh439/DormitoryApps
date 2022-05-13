using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
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
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<List<Electricity>>(ControllerName);
                    return res;
                }
                return new List<Electricity>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<List<Electricity>> GetByYear(int Year)
        {
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<List<Electricity>>($"{ControllerName}?Year={Year}");
                    return res;
                }
                return new List<Electricity>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<List<Electricity>> GetByMonth(int Year,int Month)
        {
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<List<Electricity>>($"{ControllerName}?Year={Year}&Month={Month}");
                    return res;
                }
                return new List<Electricity>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<List<Electricity>> GetByRental(string RentalId)
        {
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<List<Electricity>>($"{ControllerName}/Rental/{RentalId}");
                    return res;
                }
                return new List<Electricity>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<List<Electricity>> GetPaidList()
        {
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<List<Electricity>>($"{ControllerName}/Paid");
                    return res;
                }
                return new List<Electricity>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<List<Electricity>> GetUnPaidList()
        {
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<List<Electricity>>($"{ControllerName}/UnPaid");
                    return res;
                }
                return new List<Electricity>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<List<Electricity>?> GetAdvancedSearch(ElectricityAndWaterAdvancedSearchCriteria criteria)
        {
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.PostAsJsonAsync(ControllerName, criteria);
                    return await res.Content.ReadFromJsonAsync<List<Electricity>>();
                }
                return new List<Electricity>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<Electricity> GetOne(int Year,int Month,string RentalId)
        {
            try
            {
                var havePermission = true;
                if (havePermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<Electricity>($"{ControllerName}?Year={Year}&Month={Month}&RentalId={RentalId}");
                    return res;
                }
                return new Electricity();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Electricity item)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                if (!res.IsSuccessStatusCode) return false;
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(Electricity item)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
                if (!res.IsSuccessStatusCode) return false;
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Update(), x);
            }
            return false;
        }
        public async Task<bool> Delete(Electricity item)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", item);
                if (!res.IsSuccessStatusCode) return false;
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Electricity>.Delete(), x);
            }
            return false;
        }
        public Electricity Calculate(Electricity item, out decimal? Usage)
        {
                Usage = item.CurrentUnit - item.BeforeUnit;
                item.Total = item.Price * (Usage ?? 0);
                return item;            
        }
    }
}
