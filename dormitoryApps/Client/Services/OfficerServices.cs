using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using System.Text;
using dormitoryApps.Client.Enum;

namespace dormitoryApps.Client.Services
{
    public class OfficerServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OfficerServices> _logger;
        private readonly ILocalStorageService _localStorageService;
        public const string ControllerName = "api/officer";
        public OfficerServices(HttpClient httpClient, 
            ILogger<OfficerServices> logger,
            ILocalStorageService sessionStorageService)
        {
            _httpClient = httpClient;
            _logger = logger;
            _localStorageService = sessionStorageService;
        }
        public async Task<bool> GetLogin (string username, string password)
        {
            try
            {
                LoginParameter item = new LoginParameter();
                string cipher = password + "|" + username + "|" + item.Reference;
                item.Content = Encoding.ASCII.GetBytes(cipher);
                var response = await _httpClient.PostAsJsonAsync($"{ ControllerName}/Login", item);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Officer>.Select(), x);
            }
            return false;
        }
        public async Task Logout()
        {
            try
            {
                var sid = await _localStorageService.GetItemAsStringAsync("Id");
                await _httpClient.GetAsync($"{ ControllerName}/Logout?sid={sid}");
                await _localStorageService.ClearAsync();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Officer>.Select(), x);
            }
        }
        public async Task<List<Officer>> GetEmployee()
        {
            try
            {
                List<Officer> Employee = await _httpClient.GetFromJsonAsync<List<Officer>>(ControllerName);
                return Employee;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Officer>.Select(), x);
            }
            return null;
        }
        public async Task<Officer> GetById(long Id)
        {
            try
            {
                Officer officers = await _httpClient.GetFromJsonAsync<Officer>($"{ControllerName}/{Id}");
                return officers;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Officer>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Officer officer)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", officer);
                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Insert(), ex);
                return false;
            }
        }
         public async Task<bool> Update(Officer officer)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync<Officer>($"{ControllerName}/Update", officer);
                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Update(), ex);
                return false;
            }
        }
        public async Task<Officer> GetByUsername(string username)
        {
            try
            {
                Officer officer = await _httpClient.GetFromJsonAsync<Officer>($"{ControllerName}/User/{username}");
                return officer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Select(), ex);
                return null;
            }
        }     
        public async Task<int?> PostitionUpgrade(IEnumerable<NewPostitionParameter> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Upgrade", items);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Update(), ex);
                return null;
            }
        }
        public async Task<bool> GetExistUsername(string username)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<bool>($"{ControllerName}/ExistUsername/{username}");
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Select(), ex);
                return false;
            }
        }
        public async Task<bool> GetExistEmail(string Email)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<bool>($"{ControllerName}/ExistEmail/{Email}");
                return res;
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Select(), ex);
                return false;
            }
        }
        public async Task<bool> ExpiredOfficer(long officerId, string? remark)
        {
            try
            {
                ExpiredAndRestoreParameters parameters = new ExpiredAndRestoreParameters();
                parameters.Id = Encoding.ASCII.GetBytes(officerId.ToString());
                if (!string.IsNullOrEmpty(remark)) parameters.Comment = Encoding.ASCII.GetBytes(remark);
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Expired", parameters);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Update(), ex);
                return false;
            }
        }
         public async Task<bool> RestoreOfficer(long officerId, bool ResetRegisterddate = true)
        {
            try
            {
                ExpiredAndRestoreParameters parameters = new ExpiredAndRestoreParameters();
                parameters.Id = Encoding.ASCII.GetBytes(officerId.ToString());
                parameters.HasReset = ResetRegisterddate;
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Restored", parameters);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Update(), ex);
                return false;
            }
        }
        public async Task<bool> PasswordCheck(string password)
        {
            try
            {
                var sid = await _localStorageService.GetItemAsStringAsync("Id");
                if (string.IsNullOrEmpty(sid)) return false;
                var content = $"{password}$|{sid}";
                var data = Encoding.ASCII.GetBytes(content);
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/PasswordCheck", data);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Select(), ex);
                return false;
            }
        }
        public async Task<bool> PasswordChanges(long officerId,string newpassword,bool forgot)
        {
            try
            {
                var content = Encoding.ASCII.GetBytes($"{officerId}|{newpassword}|{forgot}");
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Newpassword", content);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ServiceException<Officer>.Update(), ex);
                return false;
            }
        }
    }
}
