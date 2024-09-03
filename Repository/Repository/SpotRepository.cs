using Business.Abstrac;
using Business.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
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

        
        public async Task<List<Spot>> GetAllAsync()
        {

            using (var _context= new ApplicationDbContext())
            {

                return await _context.Spot.OrderByDescending(k => k.kapasite).ToListAsync();
            }



           
        
            
        }

        public async Task<List<Spot>> GetByPeriodAsync(int month, int year)
        {

            using (var _context = new ApplicationDbContext())
            {
                return await _context.Spot
                             .Where(k => k.ay == month && k.yil == year)
                             .ToListAsync();

            }

           
        }

        public async Task<int> GetTotalCapacityByMonthAsync(int month, int year)
        {

            using (var _context = new ApplicationDbContext())
            {
                return await _context.Spot
                             .Where(k => k.ay == month && k.yil == year)
                             .SumAsync(k => k.kapasite);

            }


           
        }

        public async Task<double> GetTotalKapasiteByIdAsync(int kurum_id)
        {
            using (var _context = new ApplicationDbContext())
            {
                return await _context.Spot
                             .Where(k => k.Id == kurum_id)
                             .SumAsync(k => k.kapasite);

            }

        }


    }
}
