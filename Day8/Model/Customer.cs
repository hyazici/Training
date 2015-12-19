using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string HomeAddress { get; set; }

        public string WorkAddress { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
