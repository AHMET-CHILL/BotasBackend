using Business.Abstrac;
using Business.Context;
using DataAccess.Entities;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class InterruptRepository : IInterruptRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(30);


        public InterruptRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        

        public async Task<List<InterruptionReport>> GetInterruptReportAsync()
        {

            string cacheKey = "DeveciKey";

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

            
        


           

                string apiKey = "0123ASAFDSFGDSGSGJS231353513DAFASFAFAHOAJDFAFEWOUGHWGFWIGBEWUOGBWEJGWPGWRG46546846";


                List<InterruptionReport> ınterruptionReports = new List<InterruptionReport>();
                string urlPingList = "http://10.50.10.14:81/PingList";
                Uri uri = new Uri(urlPingList); //URİ BİR CLASS
                RestClient restClient = new RestClient(uri);
                RestRequest request = new RestRequest(uri, Method.Get);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Authorization", apiKey);
                var response = restClient.Execute(request);
                var PingList = JsonConvert.DeserializeObject<List<Ping>>(response.Content);
                
                
                foreach ( var device in cachedData)
                {
                    ınterruptionReports.Add(new InterruptionReport()
                    {
                        cihazAdi = device.cihazAdi,
                        status = PingList.Where(x => x.pingId == device.pingID).FirstOrDefault().status == "Up" ? true : false
                    });
                }

                return ınterruptionReports;


            
        }
    }
}
