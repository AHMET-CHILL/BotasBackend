using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstrac
{
    public interface ISpotRepository
    {
        Task<List<Spot>> GetAllAsync();
        Task<List<Spot>> GetByPeriodAsync(int month, int year);
        Task<int> GetTotalCapacityByMonthAsync(int month, int year);
        
    }
}
