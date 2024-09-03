using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstrac
{
    public interface IAkisRepository
    {
        Task<List<Akisveri>> GetByKurumIdAsync(int kurum_id);
        Task<double> GetTotalAkisByKurumIdAsync(int kurum_id);

    }
}
