using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class CountryService {
        private readonly CountryRepository countryRepository;

        public CountryService() {
            countryRepository = new CountryRepository();
        }

        public List<CountryModel> GetCountries() {
            // Add any missing business logic when it is neccesary
            return countryRepository.GetCountries();
        }
    }
}