using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Server.Services
{
    public interface IWaterServices
    {
        Task<bool> Create(Water item);
        Task<int> Create(IEnumerable<Water> items);
        Task<bool> Update(Water item);
        Task<bool> Delete(string rentalId, int month, int year);
        Task<List<Water>> Getall();
        Task<List<Water>> GetByRentalId(string rentalId);
        Task<List<Water>> GetPaid();
        Task<List<Water>> GetUnPaid();
        Task<List<Water>> GetByYear(int year);
        Task<List<Water>> GetByMonth(int year, int month);
        Task<Water> Getone(string RentalId, int month, int year);
        Task<List<Water>> GetWithAdvanceSearch(ElectricityAndWaterAdvancedSearchCriteria criteria);
    }
    public class WaterServices : IWaterServices
    {
        private readonly WaterRepository _repository;
        public WaterServices(WaterRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Water item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<Water> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(Water item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(string rentalId, int month, int year)
        {
            return await _repository.Delete(rentalId, month, year);
        }
        public async Task<List<Water>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<Water>> GetByRentalId(string rentalId)
        {
            return await _repository.GetByRentalId(rentalId);
        }
        public async Task<List<Water>> GetPaid()
        {
            return await _repository.GetPaid();
        }
        public async Task<List<Water>> GetUnPaid()
        {
            return await _repository.GetUnPaid();
        }
        public async Task<List<Water>> GetByYear(int year)
        {
            return await _repository.GetByYear(year);
        }
        public async Task<List<Water>> GetByMonth(int year, int month)
        {
            return await _repository.GetByMonth(year, month);
        }
        public async Task<Water> Getone(string RentalId, int month, int year)
        {
            return await _repository.Getone(RentalId, month, year);
        }
        public async Task<List<Water>> GetWithAdvanceSearch(ElectricityAndWaterAdvancedSearchCriteria criteria)
        {
            IEnumerable<Water> res = await _repository.GetWithAdvanceSearch(criteria);
            if (criteria.Usage.HasValue)
            {
                if (criteria.Usage == Usage.Tiny)
                {
                    res = res.Where(x => (x.CurrentUnit - x.BeforeUnit) <= 100);
                }
                else if (criteria.Usage == Usage.Minimal)
                {
                    res = res.Where(x => (x.CurrentUnit - x.BeforeUnit) > 100 && (x.CurrentUnit - x.BeforeUnit) <= 200);
                }
                else if (criteria.Usage == Usage.Normal)
                {
                    res = res.Where(x => (x.CurrentUnit - x.BeforeUnit) > 200 && (x.CurrentUnit - x.BeforeUnit) <= 500);
                }
                if (criteria.Usage == Usage.Massive)
                {
                    res = res.Where(x => (x.CurrentUnit - x.BeforeUnit) > 500);
                }

            }
            return res.ToList();
        }
    }
}
