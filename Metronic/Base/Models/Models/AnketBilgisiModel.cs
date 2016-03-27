using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponera.Base.Models
{
    // TODO : @deniz örnek paging sorting için örnek tablo
    public class AnketBilgisiModel
    {
        public int SiraNo { get; set; }

        public int? Kota { get; set; }

        public string Ilce { get; set; }

        public string Mahalle { get; set; }

        public string CepTel { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }
    }
}
