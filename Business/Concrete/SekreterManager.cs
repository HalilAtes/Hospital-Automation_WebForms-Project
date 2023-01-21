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
    public class SekreterManager : ISekreterService
    {
        IDoktorDal _doktordal;
        IHastaDal _hastadal;
        ISekreterDal _sekreterdal;

        public SekreterManager(IDoktorDal doktordal, IHastaDal hastadal,ISekreterDal sekreterdal)
        {
            _doktordal = doktordal;
            _hastadal = hastadal;
            _sekreterdal = sekreterdal;
        }


        public void Add(Doktor doktor)
        {
            _doktordal.Add(doktor);
        }
        public void Update(Doktor doktor)
        {
            _doktordal.Update(doktor);
        }
        public void Delete(int id)
        {
            _doktordal.Delete(id);
        }




        public void Add(Hasta hasta)
        {
            _hastadal.Add(hasta);
        }

        public void UpdatePatient(Hasta hasta)
        {
            _hastadal.UpdatePatient(hasta);
        }

        public void DeletePatient(int id)
        {
            _hastadal.Delete(id);
        }

        public List<Doktor> GetAllDoctors()
        {
            return _doktordal.GetAllDoctors();
        }

        public List<string> GetBranches()
        {
            return _doktordal.GetBranches();
        }

        public Doktor GetDoctorById(int id)
        {
            return _doktordal.GetDoctorById(id);
        }

        public Hasta GetPatientById(int id)
        {
            return _hastadal.GetPatientById(id);
        }

        public List<Sekreter> GetAllSecretary()
        {
            return _sekreterdal.GetAllSekreter();
        }

        public Sekreter GetSecretaryById(int id)
        {
            return _sekreterdal.GetSekreterById(id);
        }

        public void AddSecretary(Sekreter sekreter)
        {
            _sekreterdal.Add(sekreter);
        }

        public void UpdateSecretary(Sekreter sekreter)
        {
            _sekreterdal.UpdateSekreter(sekreter);
        }

        public void DeleteSecretary(int id)
        {
            _sekreterdal.Delete(id);
        }

        public List<Doktor> GetDoctorsByBranch(string branch)
        {
            return _doktordal.GetDoctorsByBranch(branch);
        }

        public int GetPatientCountByBranch(int branchId)
        {
            return _sekreterdal.GetPatientCountByBranch(branchId);
        }

        public bool CheckIfIdExistsSecreter(int idToCheck)
        {
           return _sekreterdal.CheckIfIdExistsSecreter(idToCheck);
        }

        public bool CheckIfIdExistsDoctor(int idToCheck)
        {
            return _doktordal.CheckIfIdExistsDoctor(idToCheck);
        }
        public bool CheckIfIdExistsPatient(int idToCheck)
        {
            return _hastadal.CheckIfIdExistsPatient(idToCheck);
        }
    }
}
