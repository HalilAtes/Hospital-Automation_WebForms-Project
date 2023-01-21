using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoktorService
    {

        Dictionary<string, int> GetPatientCountByDoctor();
        Dictionary<string, int> GetPatientCountByBranch();
        List<Hasta> GetPatientsByDoctorId(int doctorId);
        List<Hasta> GetAllPatients();
        void InsertGorus(int hastaId, string gorus, string sonuc);
        void UpdateKayit(Kayit kayit);
        Kayit GetKayitByHastaId(int hastaId);



    }
}
