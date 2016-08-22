using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.DAL.Conventions
{
    public class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            this.Properties<DateTime>()
                .Configure(p => p.HasColumnType("datetime2")
                .HasPrecision(0));
                
        }
    }
}
