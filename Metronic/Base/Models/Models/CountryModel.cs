using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.Models
{
    public class CountryModel
    {
        public int Id { get; set; }

        [DisplayName("İl Adı")]
        public string CountryName { get; set; }
    }
}
