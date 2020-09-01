using Microsoft.AspNetCore.Mvc;
using RedisWebAPIDemo.Services;

namespace RedisWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryMasterController : ControllerBase
    {
        private CountryMasterService _countryMasterService;
        public CountryMasterController(CountryMasterService countryMasterService)
        {
            _countryMasterService = countryMasterService;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var countryMasters = _countryMasterService.GetCountries();
            if (countryMasters != null && countryMasters.Count > 0)
                return Ok(countryMasters);
            else
                return NotFound();
        }
    }
}