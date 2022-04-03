using dormitoryApps.Shared.Model.Entity;
using Microsoft.JSInterop;
using System.Data;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class ExportServices
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExportServices> _logger;
        public const string ControllerName = "Export";
        public ExportServices(IJSRuntime jSRuntime,
                HttpClient httpClient,
                ILogger<ExportServices> logger)
        {
            _jSRuntime = jSRuntime;
            _httpClient = httpClient;
            _logger = logger;
        }
        
        public async void ExportInvoice(string invoiceId)
        {
            string url = $"{ControllerName}/Invoice/{invoiceId}";
            await  _jSRuntime.InvokeAsync<object>("open", url);
        }
        public async Task<byte[]> ExportToExcel(IEnumerable<Invoice> invoices)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/InvoiceExcel", invoices);
                return await res.Content.ReadAsByteArrayAsync();
            }
            catch(Exception x)
            {
                Console.WriteLine(x);
            }
            return null;
        }
        public async void Download(byte[] blob,string filename)
        {
            using var streamRef = new DotNetStreamReference(stream: new MemoryStream(blob));

            await _jSRuntime.InvokeAsync<object>("downloadFileFromStream", filename, streamRef);
        }
    }
}
