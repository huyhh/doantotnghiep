using HospitalAppoimentSolution.Data.Models;
using HospitalAppoimentSolution.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Services.Infrastructure;

namespace HospitalAppoimentSolution.Services.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<DoctorView> GetAll();
        IEnumerable<DoctorView> GetByDeparment(int id);
        bool Add(DoctorView model);
        bool Edit(DoctorView model);
        DoctorView GetByID(int id);
    }
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public bool Add(DoctorView model)
        {
            try
            {
                Doctor doctor = new Doctor();
                doctor.Address = model.Address;
                doctor.Avatar= "http://localhost:44351" + model.Avatar;
                doctor.BirthDay = model.BirthDay;
                doctor.DateCreate = model.DateCreate;
                doctor.Email = model.Email;
                doctor.Name = model.Name;
                doctor.Phone = model.Phone;
                doctor.Department = model.Department;
                doctor.Price = model.Price;
                DbContext.Doctors.Add(doctor);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        

        public bool Edit(DoctorView model)
        {
            try
            {
                var _item = DbContext.Doctors.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    if (!model.Avatar.Contains("http"))
                        _item.Avatar = "http://localhost:44351" + model.Avatar;
                    else
                        _item.Avatar = model.Avatar;
                    _item.Address = model.Address;
                    _item.BirthDay = model.BirthDay;
                    _item.Email = model.Email;
                    _item.Name = model.Name;
                    _item.Phone = model.Phone;
                    _item.Department = model.Department;
                    _item.Price = model.Price;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<DoctorView> GetAll()
        {
            try
            {
                var _lst = DbContext.Doctors;
                if (_lst != null && _lst.Count() > 0)
                {
                    List<DoctorView> doctors = new List<DoctorView>();
                    foreach (var item in _lst)
                    {
                        DoctorView doctor = new DoctorView();
                        doctor.Address = item.Address;
                        doctor.BirthDay = item.BirthDay;
                        doctor.DateCreate = item.DateCreate;
                        doctor.Email = item.Email;
                        doctor.ID = item.ID;
                        doctor.Name = item.Name;
                        doctor.Phone = item.Phone;
                        doctor.Department = item.Department;
                        doctor.DepartmentName = DbContext.Departments.Find(item.Department).Title;
                        doctor.Price = item.Price;
                        doctor.Avatar = item.Avatar;
                        doctors.Add(doctor);
                    }
                    return doctors;
                }
                return new List<DoctorView>();
            }
            catch (Exception)
            {

                return new List<DoctorView>();
            }
        }

        public IEnumerable<DoctorView> GetByDeparment(int id)
        {
            try
            {
                var _lst = DbContext.Doctors.Where(x => x.Department == id);
                if (_lst != null && _lst.Count() > 0)
                {
                    List<DoctorView> doctors = new List<DoctorView>();
                    foreach (var item in _lst)
                    {
                        DoctorView doctor = new DoctorView();
                        doctor.Address = item.Address;
                        doctor.BirthDay = item.BirthDay;
                        doctor.DateCreate = item.DateCreate;
                        doctor.Email = item.Email;
                        doctor.ID = item.ID;
                        doctor.Name = item.Name;
                        doctor.Phone = item.Phone;
                        doctor.Department = item.Department;
                        doctor.DepartmentName = DbContext.Departments.Find(item.Department).Title;
                        doctor.Price = item.Price;
                        doctor.Avatar = item.Avatar;
                        doctors.Add(doctor);
                    }
                    return doctors;
                }
                return new List<DoctorView>();
            }
            catch (Exception)
            {

                return new List<DoctorView>();
            }
        }

        public DoctorView GetByID(int id)
        {
            try
            {
                var _item = DbContext.Doctors.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    DoctorView doctor = new DoctorView();
                    doctor.Address = _item.Address;
                    doctor.BirthDay = _item.BirthDay;
                    doctor.DateCreate = _item.DateCreate;
                    doctor.Email = _item.Email;
                    doctor.ID = _item.ID;
                    doctor.Name = _item.Name;
                    doctor.Phone = _item.Phone;
                    doctor.Department = _item.Department;
                    doctor.DepartmentName = DbContext.Departments.Find(_item.Department).Title;
                    doctor.Price = _item.Price;
                    doctor.Avatar = _item.Avatar;
                    return doctor;
                }
                return new DoctorView();
            }
            catch (Exception)
            {

                return new DoctorView();
            }
        }
    }
}
