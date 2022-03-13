using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRoomTemplateServices
    {
        Task<bool> Create(RoomTemplate template);
        Task<bool> Update(RoomTemplate template);
        Task<bool> Delete(int templateId);
        Task<RoomTemplate> GetById(int Id);
        Task<string[]> GetNames();
        Task<bool> AddTemplate(int roomId, string roomName);
        Task<RoomTemplate> GetByName(string name);
        Task<List<RoomTemplate>> Getall();
    }
    public class RoomTemplateServices : IRoomTemplateServices
    {
        private readonly RoomTemplateRepository _repository;
        private readonly RoomfurnTemplateRepository _roomfurnTemplateRepository;

        public RoomTemplateServices(RoomTemplateRepository repository, RoomfurnTemplateRepository roomfurnTemplateRepository)
        {
            _repository = repository;
            _roomfurnTemplateRepository = roomfurnTemplateRepository;
        }
        public async Task<bool> Create(RoomTemplate template)
        {
            var res = await _repository.Create(template);
            if(template.Furnitures != null)
            {
                await _roomfurnTemplateRepository.Create(template.Furnitures);
            }
            return res;
        }
        public async Task<bool> Update(RoomTemplate template)
        {
            var res = await _repository.Update(template);
            await _roomfurnTemplateRepository.DeleteTemplate(template.Id);
            if(template.Furnitures != null)
            {
                await _roomfurnTemplateRepository.Create(template.Furnitures);
            }
            return res;
        }
        public async Task<bool> Delete(int templateId)
        {
            await _roomfurnTemplateRepository.DeleteTemplate(templateId);
            return await _repository.Delete(templateId);
        }
        public async Task<List<RoomTemplate>> Getall()
        {
            var res = await _repository.Getall();
            var furnitureList = await _roomfurnTemplateRepository.Getall();
            res.ForEach(s =>
            {
                s.Furnitures = furnitureList.Where(x => x.TemplateId == s.Id).ToList();
            });
            return res;
        }
        public async Task<RoomTemplate> GetById(int Id)
        {
            var res = await _repository.GetById(Id);
            if(res!= null) res.Furnitures = await _roomfurnTemplateRepository.GetByTemplateId(Id);
            return res;
        }
        public async Task<string[]> GetNames()
        {
            return await _repository.GetNames();
        }
        public async Task<bool> AddTemplate(int roomId, string roomName)
        {
            return await _repository.AddTemplate(roomId, roomName);
        }
        public async Task<RoomTemplate> GetByName(string name)
        {
            var res = await _repository.GetByName(name);
            if (res != null) res.Furnitures = await _roomfurnTemplateRepository.GetByTemplateId(res.Id);
            return res;
        }
    }
}
