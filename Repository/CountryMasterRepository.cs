using RedisWebAPIDemo.Models;
using System.Collections.Generic;
using System.Linq;
namespace RedisWebAPIDemo.Repository
{
    public class CountryMasterRepository
    {
        private DatabaseContext _databaseContext;
        public CountryMasterRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        internal List<CountryMaster> GetCountries()
        {
           var countryMasterList= _databaseContext.CountryMaster.ToList();
            return countryMasterList;
        }
    }
}
