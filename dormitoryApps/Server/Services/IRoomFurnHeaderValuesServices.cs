using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRoomFurnHeaderValuesServices
    {
        Task<bool> Create(RoomFurnHeaderValues item);
        Task<int> Create(IEnumerable<RoomFurnHeaderValues> values);
        Task<bool> Update(RoomFurnHeaderValues item);
        Task<bool> Delete(long Id);
        Task<int> DeleteByHeader(long headerId);
        Task<List<RoomFurnHeaderValues>> Getall();
        Task<List<RoomFurnHeaderValues>> GetByHeader(long HeaderId);
        Task<RoomFurnHeaderValues> GetById(long Id);
    }
    public class RoomFurnHeaderValuesServices : IRoomFurnHeaderValuesServices
    {
        private readonly RoomFurnHeaderValuesRepository _repository;

        public RoomFurnHeaderValuesServices(RoomFurnHeaderValuesRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(RoomFurnHeaderValues item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<RoomFurnHeaderValues> values)
        {
            return await _repository.Create(values);
        }
        public async Task<bool> Update(RoomFurnHeaderValues item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(long Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<int> DeleteByHeader(long headerId)
        {
            return await _repository.DeleteByHeader(headerId);
        }
        public async Task<List<RoomFurnHeaderValues>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<RoomFurnHeaderValues>> GetByHeader(long HeaderId)
        {
            return await _repository.GetByHeader(HeaderId);
        }
        public async Task<RoomFurnHeaderValues> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }
    }
}
