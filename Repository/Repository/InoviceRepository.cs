using Business.Abstrac;
using Business.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class InoviceRepository :IInoviceRepository
    {


        WievModelInovice Inovice = new WievModelInovice();

        public async Task<WievModelInovice> GetTotalInoviceByKurumIdAsync(int kurum_id)
        {
            using (var _context = new ApplicationDbContext())
            {
                var akismodel =  _context.Akisveri
                                  .Where(a => a.kurum_id == kurum_id).FirstOrDefault();



                Inovice.toplamKapasite= _context.Spot
                             .Where(k => k.kurum_id == kurum_id)
                             .Sum(k => k.kapasite);

                Inovice.toplamAkis = akismodel.enerji / (akismodel.basinc * akismodel.sıcaklik);

                Inovice.kapasiteBedeli = (Inovice.toplamAkis + Inovice.toplamKapasite) / 100;
                Inovice.KurumAdi = akismodel.kurumadi;

                return Inovice;

            }
        }

        
    }
}
