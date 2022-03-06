using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRoomImgServices
    {
        Task<bool> Create(RoomImg item);
        Task<int> Create(IEnumerable<RoomImg> items);
        Task<bool> Update(RoomImg item);
        Task<bool> UpdateCommit(IEnumerable<RoomImg> items);
        Task<bool> Delete(long Id);
        Task<int> DeleteByRoom(int roomId);
        Task<RoomImg> GetByRoom(int roomId);
        Task<List<RoomImg>> GetById(long Id);
    }
    public class RoomImgServices : IRoomImgServices
    {
        private readonly RoomImgRepository _repository;

        public RoomImgServices(RoomImgRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(RoomImg item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<RoomImg> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(RoomImg item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> UpdateCommit(IEnumerable<RoomImg> items)
        {
            return await _repository.UpdateCommit(items);
        }
        public async Task<bool> Delete(long Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<int> DeleteByRoom(int roomId)
        {
            return await _repository.DeleteByRoom(roomId);
        }
        public async Task<RoomImg> GetByRoom(int roomId)
        {
            return await _repository.GetByRoom(roomId);
        }
        public async Task<List<RoomImg>> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }
    }
}
