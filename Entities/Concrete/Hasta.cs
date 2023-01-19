using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Hasta : IEntity
    {
        public int Id { get; set; }
        public int doktorId { get; set; }
        public int bransId { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelNo { get; set; }
        public string GittigiBolum { get; set; }
        public int randevuId { get; set; }
    }
}
