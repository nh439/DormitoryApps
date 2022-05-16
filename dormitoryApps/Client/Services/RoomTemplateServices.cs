using dormitoryApps.Client.Enum;
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
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomTemplate>($"{ControllerName}?id={Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<List<RoomTemplate>> GetTemplates()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomTemplate>>($"{ControllerName}/all");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<RoomTemplate> GetByName(string name)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomTemplate>($"{ControllerName}/name/{name}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Select(), x);
            }
            return null;
        }

        public async Task<string[]> GetTemplateNames()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<string[]>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(RoomTemplate template)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", template);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(RoomTemplate template)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", template);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Update(), x);
            }
            return false;
        }
        public async Task<bool> Delete(int templateId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", templateId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Delete(), x);
            }
            return false;
        }
        public async Task<bool> Addtemplate(int roomId,string templateName)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/AddTemplate", new RoomTemplateAddition { roomId = roomId, roomName = templateName });
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomTemplate>.Insert(), x);
            }
            return false;
        }

    }
}
