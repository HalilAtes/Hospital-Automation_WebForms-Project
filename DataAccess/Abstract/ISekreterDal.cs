using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISekreterDal
    {
        List<Sekreter> GetAllSekreter();
        Sekreter GetSekreterById(int id);
        int GetPatientCountByBranch(int branchId);
        List<string> GetPatientsByDoctorId(int doctorId);

        void Add(Sekreter sekreter);
        void UpdateSekreter(Sekreter sekreter);
        void Delete(int id);

        bool CheckIfIdExistsSecreter(int idToCheck);
    }
}
