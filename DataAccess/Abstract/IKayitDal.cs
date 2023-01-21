using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IKayitDal
    {
        void InsertGorus(int hastaId, string gorus, string sonuc);
        void UpdateKayit(Kayit kayit);
        Kayit GetKayitByHastaId(int hastaId);
    }
}
