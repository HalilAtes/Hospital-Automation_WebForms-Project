using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISekreterService
    {
        List<Doktor> GetAllDoctors();
        List<Hasta> GetAllPatients();
        List<Sekreter> GetAllSecretary();


        Doktor GetDoctorById(int id);

        List<Doktor> GetDoctorsByBranch(string branch);
        int GetPatientCountByBranch(int branchId);

        Hasta GetPatientById(int id);
        Sekreter GetSecretaryById(int id);

        List<string> GetBranches();

        void Add(Doktor doktor);

        void Update(Doktor doktor);

        void Delete(int id);



        void Add(Hasta hasta);

        void UpdatePatient(Hasta hasta);

        void DeletePatient(int id);


        void AddSecretary(Sekreter sekreter);

        void UpdateSecretary(Sekreter sekreter);

        void DeleteSecretary(int id);
    }
}
