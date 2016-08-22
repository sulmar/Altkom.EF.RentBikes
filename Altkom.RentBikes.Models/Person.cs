using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models
{
    public class Person : Base, IDisposable
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public decimal Balance { get; set; }

        public DateTime CreatedDate { get; set; }

        public string FullName1
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        public string FullName2
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string FullName3 => $"{FirstName} {LastName}";

        public void Dispose()
        {
            Console.WriteLine("Clear...");

        }
    }
}
