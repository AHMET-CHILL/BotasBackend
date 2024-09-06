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
using static System.Net.Mime.MediaTypeNames;

namespace Business.Repository
{


    public class SpotRepository : ISpotRepository
    {
        private readonly IMemoryCache _memoryCache;

        public SpotRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<List<Spot>> GetAllAsync()
        {


            var cachedData = new CacheService().getSpotListFromCache(_memoryCache, CacheKeys.spotCacheKey);

           
            

                return cachedData.OrderByDescending(k => k.kapasite).ToList();
                
 
        }

        public async Task<List<Spot>> GetByPeriodAsync(int month, int year)
        {
            var cachedData = new CacheService().getSpotListFromCache(_memoryCache, CacheKeys.spotCacheKey);




            return cachedData.Where(k => k.ay == month && k.yil == year).ToList();

        }

        public async Task<int> GetTotalCapacityByMonthAsync(int month, int year)
        {

            var cachedData = new CacheService().getSpotListFromCache(_memoryCache, CacheKeys.spotCacheKey);


            return cachedData.Where(k => k.ay == month && k.yil == year)
                             .Sum(k => k.kapasite);
           
        }


    }
}
