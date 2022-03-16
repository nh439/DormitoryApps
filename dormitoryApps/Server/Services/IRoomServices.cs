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
        private readonly RoomFurnRepository _roomFurnRepository;
        private readonly RoomImgRepository _roomImgRepository;

        public RoomServices(RoomRepository repository,
            RoomFurnRepository roomFurnRepository,
            RoomImgRepository roomImgRepository)
        {
            _roomFurnRepository = roomFurnRepository;
            _repository = repository;
            _roomImgRepository = roomImgRepository;
        }
        public async Task<bool> Create(Room item)
        {
            item.Furniture = false;
            if (item.FurnitureList != null) item.Furniture = true;
            var res=  await _repository.Create(item);
            if (item.FurnitureList != null)
            {               
                item.FurnitureList.ForEach(x => x.RoomId = item.Id);
                await _roomFurnRepository.Create(item.FurnitureList);
            }
            if (item.Img != null && (!string.IsNullOrEmpty(item.Img.FileName) && item.Img.Img != null))
            {
                item.Img.RoomId = item.Id;
                await _roomImgRepository.Create(item.Img);
            }
            return res;
        }
        public async Task<bool> Update(Room item)
        {
            await _roomImgRepository.DeleteByRoom(item.Id);
            if(item.Img != null && (!string.IsNullOrEmpty(item.Img.FileName) && item.Img.Img !=null))
            {
                item.Img.RoomId = item.Id;
                await _roomImgRepository.Create(item.Img);
            }
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(int roomId)
        {
            await _roomImgRepository.DeleteByRoom(roomId);
            await _roomFurnRepository.DeleteRoom(roomId);
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
            var res = await _repository.GetById(id);
            if (res != null)
            {
                res.FurnitureList = await _roomFurnRepository.GetByRoom(id);
            }
            return res;
        }
    }
}
