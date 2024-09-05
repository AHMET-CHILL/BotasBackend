using Business.Abstrac;
using Business.Context;
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
        private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(30);

        public InoviceRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        WievModelInovice Inovice = new WievModelInovice();

        public async Task<WievModelInovice> GetTotalInoviceByKurumIdAsync(int kurum_id)
        {


            string akisCache = "akisCache";

            if (!_memoryCache.TryGetValue(akisCache, out List<Akisveri> akisveri))
            {
                var _context = new ApplicationDbContext();
                // Eğer cache'de yoksa veritabanına git ve veriyi al
                akisveri = _context.Akisveri.ToList();


                // Veriyi cache'e ekle
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(_cacheDuration); // Cache süresi 30 dakika

                _memoryCache.Set(akisCache, akisveri, cacheOptions);
            }

            string spotCache = "spotCache";

            if (!_memoryCache.TryGetValue(spotCache, out List<Spot> spotveri))
            {
                var _context = new ApplicationDbContext();
                // Eğer cache'de yoksa veritabanına git ve veriyi al
                spotveri = _context.Spot.ToList();


                // Veriyi cache'e ekle
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(_cacheDuration); // Cache süresi 30 dakika

                _memoryCache.Set(akisCache, akisveri, cacheOptions);
            }


            var akismodel = akisveri
                                  .Where(a => a.kurum_id == kurum_id).FirstOrDefault();



                Inovice.toplamKapasite= spotveri
                             .Where(k => k.kurum_id == kurum_id)
                             .Sum(k => k.kapasite);

                Inovice.toplamAkis = akismodel.enerji / (akismodel.basinc * akismodel.sıcaklik);

                Inovice.kapasiteBedeli = (Inovice.toplamAkis + Inovice.toplamKapasite) / 100;
                Inovice.KurumAdi = akismodel.kurumadi;

                return Inovice;

            
        }

        
    }
}
