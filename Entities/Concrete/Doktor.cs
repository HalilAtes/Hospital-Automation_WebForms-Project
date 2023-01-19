using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Doktor : IEntity
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Brans { get; set; }
        public string TelNo { get; set; }
        public string FullList { get { return Id + " " +Ad + " " + Soyad + " " + Brans + " " + TelNo; } }
    }
}
