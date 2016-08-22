using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.DAL.Configurations
{
    public class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            Property(p => p.BeginDate)
                .HasColumnType("datetime2");

            Property(p => p.EndDate)
                .HasColumnType("datetime2");

        }
    }
}
