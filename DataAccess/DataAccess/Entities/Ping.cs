using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Ping
    {
        public int Id { get; set; }
        public int pingId { get; set; }
        public string zaman { get; set; }
        public string status { get; set; }
    }
}
