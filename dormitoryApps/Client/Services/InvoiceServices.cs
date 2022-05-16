using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class InvoiceServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<InvoiceServices> _logger;
        public const string ControllerName = "api/Invoice";

        public InvoiceServices(HttpClient httpClient, SessionServices sessionServices, ILogger<InvoiceServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<Invoice>?> GetInvoices()
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>(ControllerName);
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetByYear(int year)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetByMonth(int month, int year)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}&month={month}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetByPage(int page)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetByPage(int page,int year)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}&year={year}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetByPage(int page,int year,int month)
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}&year={year}&month={month}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }

        public async Task<List<Invoice>?> GetByRental(string RentalId)
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/rental/{RentalId}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<Invoice?> GetById(string Id)
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new Invoice();
                }
                Invoice? invoices = await _httpClient.GetFromJsonAsync<Invoice>($"{ControllerName}/Id/{Id}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetPaid()
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/Paid");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetUnPaid()
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/UnPaid");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria)
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                var res = await _httpClient.PostAsJsonAsync(ControllerName, criteria);
                return await res.Content.ReadFromJsonAsync<List<Invoice>>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria,int page)
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/{page}", criteria);
                return await res.Content.ReadFromJsonAsync<List<Invoice>>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        #region Contains
        public async Task<List<Invoice>?> GetContains(string keyword)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?filter={keyword}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetContains(string keyword,int year)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}&filter={keyword}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetContains(string keyword,int month, int year)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}&month={month}&filter={keyword}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetContainsWithPage(string keyword, int page)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}&filter={keyword}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetContainsWithPage(string keyword, int page, int year)
        {
            try
            {
                var Havepermission = await _sessionServices.Permissioncheck();
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}&year={year}&filter={keyword}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        public async Task<List<Invoice>?> GetContainsWithPage(string keyword, int page, int year, int month)
        {
            try
            {
                var Havepermission = true;
                if (!Havepermission)
                {
                    return new List<Invoice>();
                }
                List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}&year={year}&month={month}&filter={keyword}");
                return invoices;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Select(), x);
            }
            return null;
        }
        #endregion
        public async Task<bool> Create(Invoice invoice)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", invoice);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Insert(), x);
            }
            return false;
        }
         public async Task<bool> Update(Invoice invoice)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", invoice);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Update(), x);
            }
            return false;
        }
         public async Task<bool> Delete(long invoiceId)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", invoiceId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Invoice>.Delete(), x);
            }
            return false;
        }
        public Invoice InvoiceCalculate(Invoice invoice)
        {
            var serviceprice = (invoice.Services != null && invoice.Services.Count > 0 ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null && invoice.Water.Total > 0 ? invoice.Water.Total : 0);
            var electricityprice = (invoice.Electricity != null && invoice.Electricity.Total > 0 ? invoice.Electricity.Total : 0);
            invoice.GrandTotal = serviceprice+waterprice + electricityprice+invoice.RentalPrice+invoice.Fee-(invoice.Discount.HasValue ? invoice.Discount.Value:0);
            invoice.ServicePrice = serviceprice;
            invoice.IsService = invoice.Services != null && invoice.Services.Count > 0;
            invoice.Tax = 0;
            return invoice;
        }
        public Invoice InvoiceCalculate(Invoice invoice,decimal taxpercentage)
        {
            var serviceprice = (invoice.Services != null && invoice.Services.Count > 0 ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null && invoice.Water.Total > 0 ? invoice.Water.Total : 0);
            var electricityprice = (invoice.Electricity != null && invoice.Electricity.Total > 0 ? invoice.Electricity.Total : 0);
            var total = serviceprice + waterprice + electricityprice + invoice.RentalPrice+invoice.Fee-(invoice.Discount?? 0);
            invoice.Tax = (taxpercentage / 100) * total;
            invoice.GrandTotal = total+invoice.Tax;
            invoice.ServicePrice = serviceprice;
            invoice.IsService = invoice.Services != null && invoice.Services.Count > 0;
            return invoice;
        }
        public Invoice InvoiceCalculate(Invoice invoice, decimal taxpercentage,decimal charge)
        {
            var serviceprice = (invoice.Services != null && invoice.Services.Count > 0 ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null && invoice.Water.Total > 0 ? invoice.Water.Total : 0);
            var electricityprice = (invoice.Electricity != null && invoice.Electricity.Total > 0 ? invoice.Electricity.Total : 0);
            var total = serviceprice + waterprice + electricityprice + invoice.RentalPrice+charge;
            invoice.Tax = (taxpercentage / 100) * total;
            invoice.GrandTotal = total + invoice.Tax;
            invoice.ServicePrice = serviceprice;
            invoice.IsService = invoice.Services != null && invoice.Services.Count > 0;
            return invoice;
        }
        public Invoice InvoiceCalculate(Invoice invoice, decimal taxpercentage,decimal charge,decimal discount)
        {
            var serviceprice = (invoice.Services != null && invoice.Services.Count > 0 ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null && invoice.Water.Total > 0 ? invoice.Water.Total : 0);
            var electricityprice = (invoice.Electricity != null && invoice.Electricity.Total > 0 ? invoice.Electricity.Total : 0);
            var total = (serviceprice + waterprice + electricityprice + invoice.RentalPrice+charge)-discount;
            invoice.Tax = (taxpercentage / 100) * total;
            invoice.GrandTotal = total + invoice.Tax;
            invoice.ServicePrice = serviceprice;
            invoice.IsService = invoice.Services != null && invoice.Services.Count > 0;
            return invoice;
        }


    }
}
