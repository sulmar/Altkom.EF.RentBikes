using Altkom.RentBikes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.DAL.Configurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
           ToTable("Persons");

            Property(p => p.FirstName)                
                .HasMaxLength(50);

            Property(p => p.LastName)
                .HasMaxLength(50);
        }
    }
}
