using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Server.Services
{
    public interface IElectricityServices
    {
        Task<bool> Create(Electricity item);
        Task<int> Create(IEnumerable<Electricity> items);
        Task<bool> Update(Electricity item);
        Task<bool> Delete(string rentalId, int month, int year);
        Task<List<Electricity>> Getall();
        Task<List<Electricity>> GetByRentalId(string rentalId);
        Task<List<Electricity>> GetPaid();
        Task<List<Electricity>> GetUnPaid();
        Task<List<Electricity>> GetByYear(int year);
        Task<List<Electricity>> GetByMonth(int year, int month);
        Task<Electricity> Getone(string RentalId, int month, int year);
        Task<Electricity> GetByInvoiceId(string invoiceId);
        Task<List<Electricity>> GetWithAdvanceSearch(ElectricityAndWaterAdvancedSearchCriteria criteria);
    }
    public class ElectricityServices : IElectricityServices
    {
        private readonly ElectricityRepository _repository;
        public ElectricityServices(ElectricityRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Electricity item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<Electricity> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(Electricity item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(string rentalId, int month, int year)
        {
            return await _repository.Delete(rentalId, month, year);
        }
        public async Task<List<Electricity>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<Electricity>> GetByRentalId(string rentalId)
        {
            return await _repository.GetByRentalId(rentalId);
        }
        public async Task<List<Electricity>> GetPaid()
        {
            return await _repository.GetPaid();
        }
        public async Task<List<Electricity>> GetUnPaid()
        {
            return await _repository.GetUnPaid();
        }
        public async Task<List<Electricity>> GetByYear(int year)
        {
            return await _repository.GetByYear(year);
        }
        public async Task<List<Electricity>> GetByMonth(int year, int month)
        {
            return await _repository.GetByMonth(year, month);
        }
        public async Task<Electricity> Getone(string RentalId, int month, int year)
        {
            return await _repository.Getone(RentalId, month, year); 
        }
        public async Task<Electricity> GetByInvoiceId(string invoiceId)
        {
            return await _repository.GetByInvoiceId(invoiceId);
        }
        public async Task<List<Electricity>> GetWithAdvanceSearch(ElectricityAndWaterAdvancedSearchCriteria criteria)
        {
            IEnumerable<Electricity> res = await _repository.GetWithAdvanceSearch(criteria);
            if(criteria.Usage.HasValue)
            {
                if(criteria.Usage==Usage.Tiny)
                {
                    res = res.Where(x => (x.CurrentUnit - x.BeforeUnit) <= 100);
                }
                else if (criteria.Usage==Usage.Minimal)
                {
                    res = res.Where(x => (x.CurrentUnit - x.BeforeUnit) > 100 && (x.CurrentUnit - x.BeforeUnit) <= 200);
                }
                else if (criteria.Usage==Usage.Normal)
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
