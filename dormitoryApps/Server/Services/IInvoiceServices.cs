using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Server.Services
{
    public interface IInvoiceServices
    {
        Task<bool> Create(Invoice item);
        Task<bool> Update(Invoice item);
        Task<bool> Delete(long InvoiceId);
        Task<List<Invoice>> GetAll();
        Task<List<Invoice>> GetPaid();
        Task<List<Invoice>> GetUnPaid();
        Task<List<Invoice>> GetByYear(int year);
        Task<List<Invoice>> GetByMonth(int Month, int year);
        Task<List<Invoice>> GetByRental(string RentalId);
        Task<Invoice> GetById(long InvoiceId);
        Task<List<Invoice>> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria);
    }
    public class InvoiceServices : IInvoiceServices
    {
        private readonly InvoiceRepository _repository;

        public InvoiceServices(InvoiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Invoice item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(Invoice item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(long InvoiceId)
        {
            return await _repository.Delete(InvoiceId);
        }
        public async Task<List<Invoice>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<List<Invoice>> GetPaid()
        {
            return await _repository.GetPaid();
        }
        public async Task<List<Invoice>> GetUnPaid()
        {
            return await _repository.GetUnPaid();
        }
        public async Task<List<Invoice>> GetByYear(int year)
        {
            return await _repository.GetByYear(year);
        }
        public async Task<List<Invoice>> GetByMonth(int Month, int year)
        {
            return await _repository.GetByMonth(Month, year);
        }
        public async Task<List<Invoice>> GetByRental(string RentalId)
        {
            return await _repository.GetByRental(RentalId);
        }
        public async Task<Invoice> GetById(long InvoiceId)
        {
            return await _repository.GetById(InvoiceId);
        }
        public async Task<List<Invoice>> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria)
        {
            return await _repository.GetWithAdvancesearch(criteria);
        }
    }
}
