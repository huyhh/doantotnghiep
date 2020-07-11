using HospitalAppoimentSolution.Data.Models;
using HospitalAppoimentSolution.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppoimentSolution.Services.Infrastructure;

namespace HospitalAppoimentSolution.Services.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IEnumerable<PatientView> GetAll();
        bool Add(PatientView model);
        bool Edit(PatientView model);
        bool CheckExistsAccount(string account, int id);
        PatientView GetByID(int id);
        ResponseMemberLogin Login(LoginModel model);
        bool ChangePass(ChangePassView model);

    }
    public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public PatientRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public bool Add(PatientView model)
        {
            try
            {
                Patient patient = new Patient();
                patient.Account = model.Account;
                patient.Address = model.Address;
                patient.BirthDay = model.BirthDay;
                patient.DateCreate = model.DateCreate;
                patient.Email = model.Email;
                patient.Name = model.Name;
                patient.Password = model.Password;
                patient.Phone = model.Phone;
                DbContext.Patients.Add(patient);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ChangePass(ChangePassView model)
        {
            try
            {
                var _item = DbContext.Patients.FirstOrDefault(x => x.Account == model.Account && x.Password == model.OldPass);
                if (_item != null && _item.Account != "")
                {
                    _item.Password = model.NewPass;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool CheckExistsAccount(string account, int id)
        {
            try
            {
                var _item = DbContext.Patients.FirstOrDefault(x => x.Account == account && x.ID != id);
                if (_item != null && _item.ID != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(PatientView model)
        {
            try
            {
                var _item = DbContext.Patients.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    _item.Account = model.Account;
                    _item.Address = model.Address;
                    _item.BirthDay = model.BirthDay;
                    _item.Email = model.Email;
                    _item.Name = model.Name;
                    _item.Password = model.Password;
                    _item.Phone = model.Phone;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<PatientView> GetAll()
        {
            try
            {
                var _lst = DbContext.Patients;
                if (_lst != null && _lst.Count() > 0)
                {
                    List<PatientView> patients = new List<PatientView>();
                    foreach (var item in _lst)
                    {
                        PatientView patient = new PatientView();
                        patient.Account = item.Account;
                        patient.Address = item.Address;
                        patient.BirthDay = item.BirthDay;
                        patient.DateCreate = item.DateCreate;
                        patient.Email = item.Email;
                        patient.ID = item.ID;
                        patient.Name = item.Name;
                        patient.Password = item.Password;
                        patient.Phone = item.Phone;
                        patients.Add(patient);
                    }
                    return patients;
                }
                return new List<PatientView>();
            }
            catch (Exception)
            {

                return new List<PatientView>();
            }
        }

        public PatientView GetByID(int id)
        {
            try
            {
                var _item = DbContext.Patients.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    PatientView patient = new PatientView();
                    patient.Account = _item.Account;
                    patient.Address = _item.Address;
                    patient.BirthDay = _item.BirthDay;
                    patient.DateCreate = _item.DateCreate;
                    patient.Email = _item.Email;
                    patient.ID = _item.ID;
                    patient.Name = _item.Name;
                    patient.Password = _item.Password;
                    patient.Phone = _item.Phone;
                    return patient;
                }
                return new PatientView();
            }
            catch (Exception)
            {

                return new PatientView();
            }
        }

        public ResponseMemberLogin Login(LoginModel model)
        {
            try
            {
                ResponseMemberLogin response = new ResponseMemberLogin();
                var member = DbContext.Patients.FirstOrDefault(x => x.Account == model.Username && x.Password == model.Password);
                if (member != null && member.ID != 0)
                {
                    response.ID = member.ID;
                    response.Name = member.Name;
                    return response;
                }
                else
                    return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }
    }
}
