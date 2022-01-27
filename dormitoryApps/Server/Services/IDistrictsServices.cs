using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.location;

namespace dormitoryApps.Server.Services
{
    public interface IDistrictsServices
    {
        Task<List<Districts>> Getall();
        Task<List<Districts>> GetByProvince(string province);
        Task<IEnumerable<string>> GetProvince();
        Task<IEnumerable<string>> Getdistricts(string province);
        Task<IEnumerable<string>> GetSubdistricts(string province, string district);
        Task<int> GetPostalCode(string province, string district, string Subdistrict);
    }
    public class DistrictsServices:IDistrictsServices
    {
        private readonly DistrictsRepository _repository;

        public DistrictsServices(DistrictsRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Districts>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<Districts>> GetByProvince(string province)
        {
            return await _repository.GetByProvince(province);
        }
        public async Task<IEnumerable<string>> GetProvince()
        {
            return await _repository.GetProvince();
        }
        public async Task<IEnumerable<string>> Getdistricts(string province)
        {
            return await _repository.Getdistricts(province);
        }
        public async Task<IEnumerable<string>> GetSubdistricts(string province, string district)
        {
            return await _repository.GetSubdistricts(province, district);
        }
        public async Task<int> GetPostalCode(string province, string district, string Subdistrict)
        {
            return await _repository.GetPostalCode(province, district, Subdistrict);
        }
    }
}
