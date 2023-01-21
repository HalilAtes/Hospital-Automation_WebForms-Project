using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDoktorDal
    {
        List<Doktor> GetAllDoctors();
        List<string> GetBranches();
        Doktor GetDoctorById(int id);
        List<Doktor> GetDoctorsByBranch(string branch);

        void Add(Doktor doktor);
        void Update(Doktor doktor);
        void Delete(int id);
        bool CheckIfIdExistsDoctor(int idToCheck);
    }
}
