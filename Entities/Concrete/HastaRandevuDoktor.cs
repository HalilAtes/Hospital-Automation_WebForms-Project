using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class HastaRandevuDoktor : IEntity
    {
        public int RandevuId { get; set; }
        public string HastaAd { get; set; }
        public string HastaSoyad { get; set; }
        public string TelNo { get; set; }
        public string Bolum { get; set; }
        public string DoktorAd { get; set; }
        public string DoktorSoyad { get; set; }

    }
}
