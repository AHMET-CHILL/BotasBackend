using Business.Context;
using DataAccess.Entities;
using DataAccess.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CacheService
    {
        
        private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(30);
      

        public List<Device> getDeviceListFromCache(IMemoryCache _memoryCache,string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out List<Device> cachedData))
            {
                var _context = new ApplicationDbContext();
                // Eğer cache'de yoksa veritabanına git ve veriyi al
                cachedData = _context.Device.ToList();


                // Veriyi cache'e ekle
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(_cacheDuration); // Cache süresi 30 dakika

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }

            return cachedData;

        }


        public List<Spot> getSpotListFromCache(IMemoryCache _memoryCache,string cacheKey)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out List<Spot> cachedData))
            {
                var _context = new ApplicationDbContext();
                // Eğer cache'de yoksa veritabanına git ve veriyi al
                cachedData = _context.Spot.ToList();


                // Veriyi cache'e ekle
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(_cacheDuration); // Cache süresi 30 dakika

                _memoryCache.Set(cacheKey, cachedData, cacheOptions);
            }


            return cachedData;

        }

        public List<Akisveri> GetAkisveriListFromCache(IMemoryCache _memoryCache,string cacheKey)
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


            return cachedData;

        }






    }
}
