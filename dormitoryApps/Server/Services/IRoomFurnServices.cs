using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRoomFurnServices
    {
        Task<bool> Create(RoomFurn item);
        Task<int> Create(IEnumerable<RoomFurn> items);
        Task<bool> Update(RoomFurn item);
        Task<bool> Delete(long Id);
        Task<int> DeleteRoom(int RoomId);
        Task<bool> UpdateRoom(IEnumerable<RoomFurn> items);
        Task<List<RoomFurn>> Getall();
        Task<List<RoomFurn>> GetByRoom(int RoomId);
        Task<RoomFurn> GetById(long Id);
    }
    public class RoomFurnService : IRoomFurnServices
    {
        private readonly RoomFurnRepository _repository;
        public RoomFurnService(RoomFurnRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(RoomFurn item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<RoomFurn> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(RoomFurn item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(long Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<int> DeleteRoom(int RoomId)
        {
            return await _repository.DeleteRoom(RoomId);
        }
        public async Task<bool> UpdateRoom(IEnumerable<RoomFurn> items)
        {
            return await _repository.UpdateRoom(items);
        }
        public async Task<List<RoomFurn>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<RoomFurn>> GetByRoom(int RoomId)
        {
            return await _repository.GetByRoom(RoomId);
        }
        public async Task<RoomFurn> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }
    }
}
