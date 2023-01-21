using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DoktorManager : IDoktorService
    {
        IHastaDal _hastadal;
        IKayitDal _kayitdal;

        public DoktorManager(IHastaDal hastadal, IKayitDal kayitdal)
        {
            _hastadal = hastadal;
            _kayitdal = kayitdal;
        }

        public List<Hasta> GetAllPatients()
        {
            return _hastadal.GetAllPatients();
        }

        public Kayit GetKayitByHastaId(int hastaId)
        {
            return _kayitdal.GetKayitByHastaId(hastaId);
        }

        public Dictionary<string, int> GetPatientCountByBranch()
        {
            return _hastadal.GetPatientCountByBranch();
        }

        public Dictionary<string, int> GetPatientCountByDoctor()
        {
            return _hastadal.GetPatientCountByDoctor();
        }

        public List<Hasta> GetPatientsByDoctorId(int doctorId)
        {
            return _hastadal.GetPatientsByDoctorId(doctorId);
        }

        public void InsertGorus(int hastaId, string gorus, string sonuc)
        {
            _kayitdal.InsertGorus(hastaId ,gorus, sonuc);
        }

        public void UpdateKayit(Kayit kayit)
        {
            _kayitdal.UpdateKayit(kayit);
        }
    }
}
