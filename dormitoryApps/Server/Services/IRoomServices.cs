using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRoomServices
    {
        Task<bool> Create(Room item);
        Task<bool> Update(Room item);
        Task<bool> Delete(int roomId);
        Task<List<Room>> Getall();
        Task<List<Room>> GetByBuilding(int buildingId);
        Task<List<Room>> GetHasAircondition();
        Task<List<Room>> GetEnabled();
        Task<Room> GetById(int id);
    }
    public class RoomServices:IRoomServices
    {
        private readonly RoomRepository _repository;

        public RoomServices(RoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Room item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(Room item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(int roomId)
        {
            return await _repository.Delete(roomId);
        }
        public async Task<List<Room>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<Room>> GetByBuilding(int buildingId)
        {
            return await _repository.GetByBuilding(buildingId);
        }
        public async Task<List<Room>> GetHasAircondition()
        {
            return await _repository.GetHasAircondition();
        }
        public async Task<List<Room>> GetEnabled()
        {
            return await _repository.GetEnabled();
        }
        public async Task<Room> GetById(int id)
        {
            return await _repository.GetById(id);             
        }
    }
}
