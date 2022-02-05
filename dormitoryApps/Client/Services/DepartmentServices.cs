﻿using dormitoryApps.Shared.Model.Entity;
using System.Net.Http;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class DepartmentServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/department";
        public DepartmentServices(HttpClient httpClient,
            ILogger<DepartmentServices> logger, SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;
        }
        public async Task< List<Department>?> Getdepartments()
        {
            var res = await _sessionServices.Permissioncheck();
            Console.WriteLine(res);
            if (res)
            {
                return await _httpClient.GetFromJsonAsync<List<Department>>(ControllerName);
            }
            return new List<Department>();
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