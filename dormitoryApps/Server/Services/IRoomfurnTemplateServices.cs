using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRoomfurnTemplateServices
    {
        Task<bool> Create(RoomfurnTemplate template);
        Task<int> Create(IEnumerable<RoomfurnTemplate> templates);
        Task<bool> Update(RoomfurnTemplate template);
        Task<bool> Delete(long Id);
        Task<int> DeleteTemplate(int roomId);
        Task<List<RoomfurnTemplate>> Getall();
        Task<List<RoomfurnTemplate>> GetByType(string typeName);
        Task<RoomfurnTemplate> GetById(long id);
    }
    public class RoomfurnTemplateServices : IRoomfurnTemplateServices
    {
        private readonly RoomfurnTemplateRepository _repository;

        public RoomfurnTemplateServices(RoomfurnTemplateRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(RoomfurnTemplate template)
        {
            return await _repository.Create(template);
        }
        public async Task<int> Create(IEnumerable<RoomfurnTemplate> templates)
        {
            return await _repository.Create(templates);
        }
        public async Task<bool> Update(RoomfurnTemplate template)
        {
            return await _repository.Update(template);
        }
        public async Task<bool> Delete(long Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<int> DeleteTemplate(int roomId)
        {
            return await _repository.DeleteTemplate(roomId);
        }
        public async Task<List<RoomfurnTemplate>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<RoomfurnTemplate>> GetByRoomId(int roomId)
        {
            return await _repository.GetByRoomId(roomId);
        }
        public async Task<List<RoomfurnTemplate>> GetByType(string typeName)
        {
            return await _repository.GetByType(typeName);
        }
        public async Task<RoomfurnTemplate> GetById(long id)
        {
            return await _repository.GetById(id);
        }
    }
}
