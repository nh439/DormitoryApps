using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IPostitionLineServices
    {
        Task<bool> Create(PostitionLine item);
        Task<bool> Update(PostitionLine item);
        Task<bool> Delete(int Id);
        Task<List<PostitionLine>> Getall();
        Task<PostitionLine> GetById(int id);
    }
    public class PostitionLineServices : IPostitionLineServices
    {
        private readonly PostitionLineRepository _repository;
        private readonly PostitionRepository _postitionRepository;

        public PostitionLineServices(PostitionLineRepository repository, PostitionRepository postitionRepository)
        {
            _repository = repository;
            _postitionRepository = postitionRepository;
        }
        public async Task<bool> Create(PostitionLine item)
        {
            if(item.Postitions != null)
            {
               await _postitionRepository.Create(item.Postitions);
            }
            return await _repository.Create(item);
        }
        public async Task<bool> Update(PostitionLine item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(int Id)
        {
            var preDeleted = await _repository.GetById(Id);
            if(preDeleted.Postitions != null)
            {
                foreach(var post in preDeleted.Postitions)
                {
                   await _postitionRepository.Deleted(post.Id);
                }
            }
            return await _repository.Delete(Id);
        }
        public async Task<List<PostitionLine>> Getall()
        {
            return  await _repository.Getall();
        }
        public async Task<PostitionLine> GetById(int id)
        {
            var res = await _repository.GetById(id);
            res.Postitions = await _postitionRepository.GetByPostitionLine(id);
            return res;
        }

    }
}
