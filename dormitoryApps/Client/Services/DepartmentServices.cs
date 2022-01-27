using dormitoryApps.Shared.Model.Entity;
using System.Net.Http;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class DepartmentServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        public const string ControllerName = "api/department";
        public DepartmentServices(HttpClient httpClient,ILogger<DepartmentServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task< List<Department>?> Getdepartments()
        {
            return await _httpClient.GetFromJsonAsync<List<Department>>(ControllerName);      
        }
        public async Task<Department?> GetById(int Id)
        {         
            return await _httpClient.GetFromJsonAsync<Department>($"{ControllerName}/{Id}");           
        }
        public async Task<bool> Create(Department item)
        {       
            var res = await _httpClient.PostAsJsonAsync<Department>($"{ControllerName}/Create", item);
            return res.IsSuccessStatusCode;
        }
    }
}
