using Business.Abstrac;
using Business.Context;
using Business.Services;
using Business.Utilities;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class AkisRepository : IAkisRepository
    {


        private readonly IMemoryCache _memoryCache;

        public AkisRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<List<Akisveri>> GetByKurumIdAsync(int kurumId)
        {

            var cachedData = new CacheService().GetAkisveriListFromCache(_memoryCache, CacheKeys.akisveriCachekey);

            return cachedData.Where(a => a.kurum_id == kurumId).ToList();
                                
                                 

            
          
        }

        public async Task<double> GetTotalAkisByKurumIdAsync(int kurumId)
        {
            var cachedData = new CacheService().GetAkisveriListFromCache(_memoryCache, CacheKeys.akisveriCachekey);


            return cachedData.Where(a => a.kurum_id == kurumId).Sum(a => (a.basinc * a.sıcaklik) / a.enerji)
                                  
                                  ;

            


            
        }
    }

}
