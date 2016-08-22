using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models
{
    public class Rental : Base
    {
        public int RentalId { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        // navigation property

        public Person Rentee { get; set; }
        
        public Bike Bike { get; set; }

        public Station FromStation { get; set; }

        public Station ToStation { get; set; }
    }
}
