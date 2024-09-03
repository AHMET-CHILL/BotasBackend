using Business.Abstrac;
using Business.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class AkisRepository : IAkisRepository
    {

        public async Task<List<Akisveri>> GetByKurumIdAsync(int kurumId)
        {

            using (var _context = new ApplicationDbContext())
            {
                return await _context.Akisveri
                                 .Where(a => a.kurum_id == kurumId)
                                 .ToListAsync();

            }
          
        }

        public async Task<double> GetTotalAkisByKurumIdAsync(int kurumId)
        {

            using (var _context = new ApplicationDbContext())
            {
                return await _context.Akisveri
                                  .Where(a => a.kurum_id == kurumId)
                                  .SumAsync(a => (a.basinc * a.sıcaklik) / a.enerji);

            }


            
        }
    }

}
