using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRoomFurnHeaderServices
    {
        Task<bool> Create(RoomFurnHeader item);
        Task<int> Create(IEnumerable<RoomFurnHeader> items);
        Task<bool> Update(RoomFurnHeader item);
        Task<bool> Delete(long itemId);
        Task<int> DeleteByType(string itemType);
        Task<List<RoomFurnHeader>> Getall();
        Task<List<RoomFurnHeader>> GetByType(string type);
        Task<List<RoomFurnHeader>> GetContains(string keyword);
        Task<RoomFurnHeader> GetById(long Id);
        Task<string[]> GetTypes();
    }
    public class RoomFurnHeaderServices : IRoomFurnHeaderServices
    {
        private readonly RoomFurnHeaderRepository _repository;
        private readonly RoomFurnHeaderValuesRepository _roomFurnHeaderValuesRepository;

        public RoomFurnHeaderServices(RoomFurnHeaderRepository repository, RoomFurnHeaderValuesRepository roomFurnHeaderValuesRepository)
        {
            _repository = repository;
            _roomFurnHeaderValuesRepository = roomFurnHeaderValuesRepository;
        }
        public async Task<bool> Create(RoomFurnHeader item)
        {
            if(item.values != null && !item.CustomValue)
            {
                await _roomFurnHeaderValuesRepository.Create(item.values);
            }
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<RoomFurnHeader> items)
        {
            foreach(var item in items)
            {
                if(item.values != null)
                {
                    await _roomFurnHeaderValuesRepository.Create(item.values);
                }
            }
            return await _repository.Create(items);
        }
        public async Task<bool> Update(RoomFurnHeader item)
        {
            if(!item.CustomValue)
            {
                await _roomFurnHeaderValuesRepository.DeleteByHeader(item.Id);
                if(item.values != null)
                {
                    await _roomFurnHeaderValuesRepository.Create(item.values);
                }
            }
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(long itemId)
        {
            await _roomFurnHeaderValuesRepository.DeleteByHeader(itemId);
            return await _roomFurnHeaderValuesRepository.Delete(itemId);
        }
        public async Task<int> DeleteByType(string itemType)
        {
            var predeletetype = await _repository.GetByType(itemType);
            foreach(var item in predeletetype)
            {
                await _roomFurnHeaderValuesRepository.DeleteByHeader(item.Id);
            }
            return await _repository.DeleteByType(itemType);
        }
        public async Task<List<RoomFurnHeader>> Getall()
        {
            var res = await _repository.Getall();
            res.ForEach(async x =>
            {
                x.values = await _roomFurnHeaderValuesRepository.GetByHeader(x.Id);
            });
            return res;
        }
        public async Task<List<RoomFurnHeader>> GetContains(string keyword)
        {
            var res = await _repository.GetContains(keyword);
            res.ForEach(async x =>
            {
                x.values = await _roomFurnHeaderValuesRepository.GetByHeader(x.Id);
            });
            return res;
        }
        public async Task<List<RoomFurnHeader>> GetByType(string type)
        {
            var res = await _repository.GetByType(type);
            res.ForEach(async x =>
            {
                x.values = await _roomFurnHeaderValuesRepository.GetByHeader(x.Id);
            });
            return res;               
        }
        public async Task<RoomFurnHeader> GetById(long Id)
        {
            var res = await _repository.GetById(Id);
            res.values = await _roomFurnHeaderValuesRepository.GetByHeader(Id);
            return res;
        }
        public async Task<string[]> GetTypes()
        {
            return await _repository.GetTypes();
        }
    }
}
