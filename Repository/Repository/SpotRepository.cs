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
using static System.Net.Mime.MediaTypeNames;

namespace Business.Repository
{


    public class SpotRepository : ISpotRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(30);

        public  SpotRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            
        }

        string cacheKey = "spotKey";

        public async Task<List<Spot>> GetAllAsync()
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

           
            

                return cachedData.OrderByDescending(k => k.kapasite).ToList();
                
 
        }

        public async Task<List<Spot>> GetByPeriodAsync(int month, int year)
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


            
                     return cachedData.Where(k => k.ay == month && k.yil == year).ToList();

        }

        public async Task<int> GetTotalCapacityByMonthAsync(int month, int year)
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
            
            
                return cachedData.Where(k => k.ay == month && k.yil == year)
                             .Sum(k => k.kapasite);
           
        }


    }
}
