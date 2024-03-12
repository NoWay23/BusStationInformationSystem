using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationInformationSystem.Data.Entity
{
    public class Way
    {
        public Guid Id { get; set; }
         
        public int Code { get; set; }

        public string Otkuda { get; set; }

        public string Kuda { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string State { get; set; }
    }
}
