using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.DAL.Configurations
{
    public class BikeConfiguration : EntityTypeConfiguration<Bike>
    {
        public BikeConfiguration()
        {
            Property(p => p.SerialNumber)
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsRequired();
            
        }
    }
}
