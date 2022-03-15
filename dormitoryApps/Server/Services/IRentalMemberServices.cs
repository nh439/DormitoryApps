using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRentalMemberServices
    {
        Task<bool> Create(RentalMember item);
        Task<int> Create(IEnumerable<RentalMember> items);
        Task<bool> SetnewRentalIsMain(RentalMember isMainitem);
        Task<List<RentalMember>> GetByRentalId(string rentalId);
        Task<List<RentalMember>> GetByMember(long memberId);
    }
    public class RentalMemberServices : IRentalMemberServices
    {
        private readonly RentalMemberRepository _repository;
        private readonly MemberRepository _memberRepository;
        private readonly CurrentCustomerRepository _customerRepository;
        private readonly PastCustomerRepository _pastCustomerRepository;

        public RentalMemberServices(RentalMemberRepository repository, MemberRepository memberRepository, CurrentCustomerRepository customerRepository, PastCustomerRepository pastCustomerRepository)
        {
            _repository = repository;
            _memberRepository = memberRepository;
            _customerRepository = customerRepository;
            _pastCustomerRepository = pastCustomerRepository;
        }
        public async Task<bool> Create(RentalMember item)
        {
            bool res = false;
            item.MemberId = _memberRepository.Autoincrement();
            await _repository.Create(item).ContinueWith(async x =>
            {
                if (await x) 
                { 
                    item.Member.MemberId=item.MemberId;
                    await _memberRepository.Create(item.Member);
                }
                res = await x;
            });
            return res;
        }
        public async Task<int> Create(IEnumerable<RentalMember> items)
        {
            int res = 0;
            List<RentalMember> insertItem = items.ToList();
            var idSet = _memberRepository.Autoincrement(insertItem.Count);
            foreach(var (id,index) in idSet.Select((x,y)=>(x,y)))
            {
                insertItem[index].MemberId=id;
                insertItem[index].Member.MemberId=id;
            }
            await _repository.Create(insertItem).ContinueWith(async x =>
            {
                var members = insertItem.Select(x=>x.Member);
                await _memberRepository.Create(members);
                res = await x;
            });
            return res;
        }
        public async Task<bool> SetnewRentalIsMain(RentalMember isMainitem)
        {
            return await _repository.SetnewRentalIsMain(isMainitem);
        }
        public async Task<List<RentalMember>> GetByRentalId(string rentalId)
        {
            var res = await _repository.GetByRentalId(rentalId);
            var memberIdCollection = res.Select(x=>x.MemberId);
            var memberlist = await _memberRepository.GetIn(memberIdCollection);
            res.ForEach(x =>
            {
                x.Member = memberlist.Where(y => y.MemberId == x.MemberId).FirstOrDefault();
            });
            return res;
        }
        public async Task<List<RentalMember>> GetByMember(long memberId)
        {
            var res = await _repository.GetByMember(memberId);
            res.ForEach(async x =>
            {
                x.CurrentCustomer = await _customerRepository.GetById(x.RentalId);
                if (x.CurrentCustomer == null) await _pastCustomerRepository.GetById(x.RentalId);
            });
            return res;
        }

    }
}
