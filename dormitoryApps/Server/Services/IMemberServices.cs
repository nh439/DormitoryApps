using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IMemberServices
    {
        Task<bool> Create(Member item);
        Task<int> Create(IEnumerable<Member> items);
        Task<bool> Update(Member item);
        Task<List<Member>> Getall();
        Task<List<Member>> GetIn(IEnumerable<long> itemIdCollection);
        Task<Member> GetById(long id);
    }
    public class MemberServices : IMemberServices
    {
        private readonly MemberRepository _repository;

        public MemberServices(MemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Member item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<Member> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(Member item)
        {
            return await _repository.Update(item);
        }
        public async Task<List<Member>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<Member>> GetIn(IEnumerable<long> itemIdCollection)
        {
            return await _repository.GetIn(itemIdCollection);
        }
        public async Task<Member> GetById(long id)
        {
            return await _repository.GetById(id);
        }

    }
}
