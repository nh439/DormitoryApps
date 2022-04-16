﻿using dormitoryApps.Shared.Model.Json;
using System.Net.Http.Json;
namespace dormitoryApps.Client.Services
{
    public class ClientdataServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClientdataServices> _logger;
        public const string ControllerName = "data/";

        public ClientdataServices(HttpClient httpClient, ILogger<ClientdataServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<DefaultRental> GetDefaultRental()
        {
            var res = await _httpClient.GetFromJsonAsync<DefaultRental>($"{ControllerName}/Rental.json");
            return res;
        }
        public async Task<Utilities> GetUtilities()
        {
            var res = await _httpClient.GetFromJsonAsync<Utilities>($"{ControllerName}/Utilities.json");
            return res;

        }
        public async Task<MyCompany> GetMyCompany()
        {
            var res = await _httpClient.GetFromJsonAsync<MyCompany>($"{ControllerName}/MyCompany.json");
            return res;
        }
     
    }
}
