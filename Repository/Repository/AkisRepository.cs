using Business.Abstrac;
using Business.Context;
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
        private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(30);


        public AkisRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

        }

        string cacheKey = "akisveriKey";




        public async Task<List<Akisveri>> GetByKurumIdAsync(int kurumId)
        {

            if (!_memoryCache.TryGetValue(cacheKey, out List<Akisveri> cachedData))
            {
                var _context = new ApplicationDbContext();
                // Eğer cache'de yoksa veritabanına git ve veriyi al
                cachedData = _context.Akisveri.ToList();


                // Veriyi cache'e ekle
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(_cacheDuration); // Cache süresi 30 dakika

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            return cachedData.Where(a => a.kurum_id == kurumId).ToList();
                                
                                 

            
          
        }

        public async Task<double> GetTotalAkisByKurumIdAsync(int kurumId)
        {

            if (!_memoryCache.TryGetValue(cacheKey, out List<Akisveri> cachedData))
            {
                var _context = new ApplicationDbContext();
                // Eğer cache'de yoksa veritabanına git ve veriyi al
                cachedData = _context.Akisveri.ToList();


                // Veriyi cache'e ekle
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(_cacheDuration); // Cache süresi 30 dakika

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }


            return cachedData.Where(a => a.kurum_id == kurumId).Sum(a => (a.basinc * a.sıcaklik) / a.enerji)
                                  
                                  ;

            


            
        }
    }

}
