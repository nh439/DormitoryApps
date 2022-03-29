using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Server.Services
{
    public interface IInvoiceServices
    {
        Task<bool> Create(Invoice item);
        Task<bool> Update(Invoice item);
        Task<bool> Delete(string InvoiceId);
        Task<List<Invoice>> GetAll();
        Task<List<Invoice>> GetPaid();
        Task<List<Invoice>> GetUnPaid();
        Task<List<Invoice>> GetByYear(int year);
        Task<List<Invoice>> GetByMonth(int Month, int year);
        Task<List<Invoice>> GetByRental(string RentalId);
        Task<Invoice> GetById(string InvoiceId);
        Task<List<Invoice>> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria);
    }
    public class InvoiceServices : IInvoiceServices
    {
        private readonly InvoiceRepository _repository;
        private readonly InvoiceServiceRepository _invoiceserviceRepository;
        private readonly ElectricityRepository _electricityRepository;
        private readonly WaterRepository _waterRepository;
        public InvoiceServices(InvoiceRepository repository,
            InvoiceServiceRepository invoiceserviceRepository, 
            WaterRepository waterRepository,
            ElectricityRepository electricityRepository)
        {
            _repository = repository;
            _invoiceserviceRepository = invoiceserviceRepository;
            _waterRepository = waterRepository;
            _electricityRepository = electricityRepository;
            _waterRepository = waterRepository;
        }
        public async Task<bool> Create(Invoice item)
        {
            item.Id = _repository.GenerateId();
            var res =  await _repository.Create(item);
            if (item.Services != null)
            {
                item.Services.ForEach(x =>
                {
                    x.InvoiceId = item.Id;
                });
                await _invoiceserviceRepository.Create(item.Services);
            }
            if(item.Water != null && !string.IsNullOrEmpty( item.Water.RentalId))
            {
                item.Water.InvoiceId = item.Id;
                await _waterRepository.Update(item.Water);
            }
            if(item.Electricity != null && !string.IsNullOrEmpty( item.Electricity.RentalId))
            {
                item.Electricity.InvoiceId = item.Id;
                await _electricityRepository.Update(item.Electricity);
            }
            return res;
        }
        public async Task<bool> Update(Invoice item)
        {
            if (item.Water != null && item.Water != new Water())
            {
                await _waterRepository.Update(item.Water);
            }
            if (item.Electricity != null && item.Electricity != new Electricity())
            {
                await _electricityRepository.Update(item.Electricity);
            }

            return await _repository.Update(item);
        }
        public async Task<bool> Delete(string InvoiceId)
        {
            return await _repository.Delete(InvoiceId);
        }
        public async Task<List<Invoice>> GetAll()
        {
            var res = await _repository.GetAll();
            var waters = await _waterRepository.Getall();
            var electricites = await _electricityRepository.Getall();
            res.ForEach(async x =>
            {
                x.Services = await _invoiceserviceRepository.GetByInvoice(x.Id);
                x.Water = waters.Where(y => y.InvoiceId == x.Id).FirstOrDefault();
                x.Electricity = electricites.Where(y => y.InvoiceId == x.Id).FirstOrDefault();
            });
            return res;
        }
        public async Task<List<Invoice>> GetPaid()
        {
            var res= await _repository.GetPaid();
            res.ForEach(async x =>
            {
                x.Services = await _invoiceserviceRepository.GetByInvoice(x.Id);
                x.Water = await _waterRepository.GetByInvoiceId(x.Id);
                x.Electricity = await _electricityRepository.GetByInvoiceId(x.Id);
            });
            return res;
        }
        public async Task<List<Invoice>> GetUnPaid()
        {
            var res = await _repository.GetUnPaid();
            res.ForEach(async x =>
            { 
                x.Services = await _invoiceserviceRepository.GetByInvoice(x.Id);
                x.Water = await _waterRepository.GetByInvoiceId(x.Id);
                x.Electricity = await _electricityRepository.GetByInvoiceId(x.Id);
            });
            return res;
        }
        public async Task<List<Invoice>> GetByYear(int year)
        {
            var res = await _repository.GetByYear(year);
            res.ForEach(async x => { 
                x.Services = await _invoiceserviceRepository.GetByInvoice(x.Id);
                x.Water = await _waterRepository.GetByInvoiceId(x.Id);
                x.Electricity = await _electricityRepository.GetByInvoiceId(x.Id);
            });
            return res;
        }
        public async Task<List<Invoice>> GetByMonth(int Month, int year)
        {
            var res = await _repository.GetByMonth(Month, year);
            res.ForEach(async x => { 
                x.Services = await _invoiceserviceRepository.GetByInvoice(x.Id);
                x.Water = await _waterRepository.GetByInvoiceId(x.Id);
                x.Electricity = await _electricityRepository.GetByInvoiceId(x.Id);
            });
            return res;
         }
        public async Task<List<Invoice>> GetByRental(string RentalId)
        {
            var res = await _repository.GetByRental(RentalId);
            res.ForEach(async x => {
                x.Services = await _invoiceserviceRepository.GetByInvoice(x.Id);
                x.Water = await _waterRepository.GetByInvoiceId(x.Id);
                x.Electricity = await _electricityRepository.GetByInvoiceId(x.Id);
            });
            return res;
        }
        public async Task<Invoice> GetById(string InvoiceId)
        {
            var res =  await _repository.GetById(InvoiceId);
            if(res != null)
            {
                res.Services = await _invoiceserviceRepository.GetByInvoice(InvoiceId);
                res.Water = await _waterRepository.GetByInvoiceId(res.Id);
                res.Electricity = await _electricityRepository.GetByInvoiceId(res.Id);
            }
            return res;
        }
        public async Task<List<Invoice>> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria)
        {
            var res = await _repository.GetWithAdvancesearch(criteria);
            res.ForEach(async x => { 
                x.Services = await _invoiceserviceRepository.GetByInvoice(x.Id);
                x.Water = await _waterRepository.GetByInvoiceId(x.Id);
                x.Electricity = await _electricityRepository.GetByInvoiceId(x.Id);
            });
            return res;
        }
    }
}
