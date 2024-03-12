using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationInformationSystem.Data.Entity
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string PlaceOfDeparture { get; set; }

        public string Destination { get; set; }

        public int RouteNumber { get; set; }

        public int SeatNumber { get; set; }

    }
}
