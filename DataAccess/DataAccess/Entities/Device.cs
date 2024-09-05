using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public int pingID { get; set; }
        public string cihazAdi  { get; set; }
        public string cihazTuru { get; set; }
        public string ip {  get; set; }
        public string enlem { get; set; }
        public string boylam { get; set; }
        public int rootID { get; set; }


    }
}
