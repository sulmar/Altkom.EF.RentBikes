using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models
{
    public class Station : Base
    {
        public int StationId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public byte Capacity { get; set; }

        public bool IsActive { get; set; }

        //public int StationKey { get; set; }
        public DateTime ModifiedDate { get; set; }

        public DbGeography Location { get; set; }

    }
}
