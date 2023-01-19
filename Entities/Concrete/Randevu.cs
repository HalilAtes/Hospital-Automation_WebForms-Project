using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Randevu :IEntity
    {
        public int randevuId { get; set; }
        public int HastaId { get; set; }
        public DateTime Tarih { get; set; }
        public int DoktorId { get; set; }
    }
}
