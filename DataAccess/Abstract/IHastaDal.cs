using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IHastaDal
    {
        List<Hasta> GetAllPatients();
        Hasta GetPatientById(int id);

        void Add(Hasta hasta);
        void UpdatePatient(Hasta hasta);
        void Delete(int id);

    }
}
