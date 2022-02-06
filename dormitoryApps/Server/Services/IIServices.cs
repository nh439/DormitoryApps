using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IIServices
    {
        Task<bool> Create(InvoiceService item);
        Task<int> Create(IEnumerable<InvoiceService> items);
        Task<bool> Update(InvoiceService item);
        Task<bool> Delete(InvoiceService item);
        Task<List<InvoiceService>> GetByInvoice(string invoiceId);
        Task<List<InvoiceService>> GetByService(long serviceId);
    }
    public class iIService : IIServices
    {
        private readonly InvoiceServiceRepository _repository;

        public iIService(InvoiceServiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(InvoiceService item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<InvoiceService> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(InvoiceService item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(InvoiceService item)
        {
            return await _repository.Delete(item);
        }
        public async Task<List<InvoiceService>> GetByInvoice(string invoiceId)
        {
            return await _repository.GetByInvoice(invoiceId);
        }
        public async Task<List<InvoiceService>> GetByService(long serviceId)
        {
            return await _repository.GetByService(serviceId);
        }

    }
}
