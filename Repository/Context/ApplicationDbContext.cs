using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Business.Context
{
    public class ApplicationDbContext : DbContext
    {
      

        public DbSet<Spot> Spot { get; set; }
        public DbSet<Akisveri> Akisveri { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-QF19LOE\\SQLEXPRESS02; Database = BackendProject; Trusted_Connection = True; Encrypt = False; TrustServerCertificate = False; ", null);
        }
    }

}
