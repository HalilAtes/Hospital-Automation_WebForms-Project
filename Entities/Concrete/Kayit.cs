using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Kayit :IEntity
    {
        public int HastaId { get; set; }
        public string Gorus { get; set; }
        public string Sonuc { get; set; }
    }
}
