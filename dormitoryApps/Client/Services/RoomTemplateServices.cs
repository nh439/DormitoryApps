using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RoomTemplateServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RoomTemplateServices> _logger;     
        public const string ControllerName = "api/RoomTemplate";

        public RoomTemplateServices(HttpClient httpClient, ILogger<RoomTemplateServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<RoomTemplate> GetById(int Id)
        {
            var res = await _httpClient.GetFromJsonAsync<RoomTemplate>($"{ControllerName}?id={Id}");
            return res;
        }
        public async Task<string[]> GetTemplateNames()
        {
            var res = await _httpClient.GetFromJsonAsync<string[]>(ControllerName);
            return res;
        }
        public async Task<bool> Create(RoomTemplate template)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create",template);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Update(RoomTemplate template)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update",template);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(int templateId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete",templateId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Addtemplate(int roomId,string templateName)
        {           
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/AddTemplate",new RoomTemplateAddition { roomId=roomId,roomName=templateName});
            return await res.Content.ReadFromJsonAsync<bool>();
        }

    }
}
