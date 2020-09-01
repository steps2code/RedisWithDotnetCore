using Microsoft.Extensions.Caching.Distributed;
using RedisWebAPIDemo.Models;
using RedisWebAPIDemo.Repository;
using System.Collections.Generic;

namespace RedisWebAPIDemo.Services
{
    public class CountryMasterService
    {
        private CountryMasterRepository _countryMasterRepository;
        private IDistributedCache _distributedCache;
        private const string COUNTRYMASTER_REDIS_KEY = "CountryMaster";
        public CountryMasterService(CountryMasterRepository countryMasterRepository, IDistributedCache distributedCache)
        {
            _countryMasterRepository = countryMasterRepository;
            _distributedCache = distributedCache;
        }

        internal List<CountryMaster> GetCountries()
        {
            // Get the cached item
            List<CountryMaster> countryMastersList;
            countryMastersList = CacheRepository.GetObjectAsync<List<CountryMaster>>(_distributedCache, COUNTRYMASTER_REDIS_KEY).GetAwaiter().GetResult(); ;
            if (countryMastersList == null || (countryMastersList != null && countryMastersList.Count == 0))
            {
                countryMastersList = _countryMasterRepository.GetCountries();
                CacheRepository.SetObjectAsync(_distributedCache, COUNTRYMASTER_REDIS_KEY, countryMastersList).GetAwaiter().GetResult(); ;
            }
            return countryMastersList;
        }
    }
}
