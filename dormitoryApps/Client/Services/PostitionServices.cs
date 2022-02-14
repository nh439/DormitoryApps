using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class PostitionServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<InvoiceServices> _logger;
        public const string ControllerName = "api/Postition";

        public PostitionServices(HttpClient httpClient,
            SessionServices sessionServices,
            ILogger<InvoiceServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<Postition>> GetPostitions()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Postition>>(ControllerName);
                return res;
            }
            catch(Exception x)
            {
                _logger.LogError(x.Message,x);
            }
            return new List<Postition>();
        }
        public async Task<List<Postition>> GetByPostitionLine(int LineId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Postition>>($"{ ControllerName}/Line/{LineId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return new List<Postition>();
        }
        public async Task<List<Postition>> GetByDepartments(int DepartmentId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Postition>>($"{ ControllerName}/Department/{DepartmentId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return new List<Postition>();
        }
        public async Task<Postition> GetById(int PostitionId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<Postition>($"{ ControllerName}?id={PostitionId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return new Postition();
        }
        public async Task<bool> Create(Postition postition)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", postition);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return false ;
        }
         public async Task<bool> Update(Postition postition)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", postition);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return false;
        }
         public async Task<bool> Deleted(int postitionId)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", postitionId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return false;
        }
        public async Task<Postition> GetNextPostition(int postitionId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<Postition>($"{ ControllerName}/Next/{postitionId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return new Postition();
        }

    }
}
