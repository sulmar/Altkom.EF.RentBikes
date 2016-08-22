using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models
{
    public class Bike : Base
    {
        public int BikeId { get; set; }

        public string SerialNumber { get; set; }

        public BikeTypes BikeType { get; set; }

        public Status Status { get; set; }

        public string Color { get; set; }

    }
}
