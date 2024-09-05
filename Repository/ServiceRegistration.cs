using Business.Abstrac;
using Business.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ServiceRegistration
    {
        public  static void addBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ISpotRepository,SpotRepository >();
            services.AddScoped<IAkisRepository, AkisRepository >();
            services.AddScoped<IInoviceRepository,InoviceRepository >();



            // Diğer servis kayıtları
        }

    }
}
