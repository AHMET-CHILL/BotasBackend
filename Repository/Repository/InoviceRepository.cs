using Business.Abstrac;
using Business.Context;
using Business.Services;
using Business.Utilities;
using DataAccess.Entities;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class InoviceRepository :IInoviceRepository
    {

        private readonly IMemoryCache _memoryCache;

        public InoviceRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        WievModelInovice Inovice = new WievModelInovice();

        public async Task<WievModelInovice> GetTotalInoviceByKurumIdAsync(int kurum_id)
        {


            var cachedAkisData = new CacheService().GetAkisveriListFromCache(_memoryCache, CacheKeys.InnoviceCacheKey);
            var cachedSpotData= new CacheService().getSpotListFromCache(_memoryCache, CacheKeys.InnoviceCacheKey);
           


            var akismodel = cachedAkisData
                                  .Where(a => a.kurum_id == kurum_id).FirstOrDefault();



                Inovice.toplamKapasite= cachedSpotData
                             .Where(k => k.kurum_id == kurum_id)
                             .Sum(k => k.kapasite);

                Inovice.toplamAkis = akismodel.enerji / (akismodel.basinc * akismodel.sıcaklik);

                Inovice.kapasiteBedeli = (Inovice.toplamAkis + Inovice.toplamKapasite) / 100;
                Inovice.KurumAdi = akismodel.kurumadi;

                return Inovice;

            
        }

        
    }
}
