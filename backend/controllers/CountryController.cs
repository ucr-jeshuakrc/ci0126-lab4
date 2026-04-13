using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase {

        private readonly CountryService _countryService;

        public CountryController() {
            _countryService = new CountryService();
        }

        [HttpGet]
        public List<CountryModel> Get() {
            return _countryService.GetCountries();
        }
    

        [HttpPost]
        public async Task<ActionResult<bool>> CreateCountry(CountryModel country) {
            if (country == null) {
                return BadRequest();
            }
            var result = _countryService.CreateCountry(country);
            if (string.IsNullOrEmpty(result)) {
                return Ok(true);
            } else {
                return BadRequest(result);
            }
        }
    }
}