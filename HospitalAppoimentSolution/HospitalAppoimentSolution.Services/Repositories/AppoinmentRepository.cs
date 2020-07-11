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
    public interface IAppoinmentRepository : IRepository<Appoinment>
    {
        IEnumerable<AppoinmentView> GetByPatient(int id);
        IEnumerable<AppoinmentView> GetByDoctor(int id);
        IEnumerable<AppoinmentView> GetAll();
        AppoinmentView GetByCode(string code);
        bool Add(AppoinmentView model);
        bool CheckTimeExists(string date, string time, int id);
        bool UpdateStatus(long id, int status);
        bool UpdatePayment(long id);
    }
    public class AppoinmentRepository : RepositoryBase<Appoinment>, IAppoinmentRepository
    {
        public AppoinmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public bool Add(AppoinmentView model)
        {
            try
            {
                Appoinment appoinment = new Appoinment();
                appoinment.Amount = model.Amount;
                appoinment.Code = model.Code;
                appoinment.Date = new DateTime(Convert.ToInt32(model.Date.Split('/')[2]), Convert.ToInt32(model.Date.Split('/')[1]), Convert.ToInt32(model.Date.Split('/')[0]));
                appoinment.IsPayment = model.IsPayment;
                appoinment.Patient = model.Patient;
                appoinment.Price = model.Price;
                appoinment.Reduce = model.Reduce;
                appoinment.Status = model.Status;
                appoinment.Time = model.Time;
                appoinment.Doctor = model.Doctor;
                DbContext.Appoinments.Add(appoinment);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CheckTimeExists(string date, string time, int id)
        {
            try
            {
                var _lst = DbContext.Appoinments.Where(x => x.Doctor == id);
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        if (item.Date.ToString("dd/MM/yyyy") == date && item.Time == time)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<AppoinmentView> GetAll()
        {
            try
            {
                var _lst = from a in DbContext.Appoinments
                           from p in DbContext.Patients
                           from d in DbContext.Doctors
                           where a.Doctor == d.ID
                           && a.Patient == p.ID
                           select new
                           {
                               ID = a.ID,
                               Code = a.Code,
                               Patient = a.Patient,
                               PatientName = p.Name,
                               Doctor = d.ID,
                               DoctorName = d.Name,
                               Date = a.Date,
                               Time = a.Time,
                               Status = a.Status,
                               IsPayment = a.IsPayment,
                               Price = a.Price,
                               Reduce = a.Reduce,
                               Amount = a.Amount
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    List<AppoinmentView> appoinments = new List<AppoinmentView>();
                    foreach (var item in _lst)
                    {
                        AppoinmentView view = new AppoinmentView();
                        view.Amount = item.Amount;
                        view.Code = item.Code;
                        view.Date = item.Date.ToString("dd/MM/yyyy");
                        view.Doctor = item.Doctor;
                        view.DoctorName = item.DoctorName;
                        view.ID = item.ID;
                        view.IsPayment = item.IsPayment;
                        view.Patient = item.Patient;
                        view.PatientName = item.PatientName;
                        view.Price = item.Price;
                        view.Reduce = item.Reduce;
                        view.Status = item.Status;
                        view.Time = item.Time;
                        appoinments.Add(view);
                    }
                    return appoinments;
                }
                return new List<AppoinmentView>();
            }
            catch (Exception)
            {

                return new List<AppoinmentView>();
            }
        }

        public AppoinmentView GetByCode(string code)
        {
            try
            {
                var _lst = from a in DbContext.Appoinments
                           from p in DbContext.Patients
                           from d in DbContext.Doctors
                           where a.Doctor == d.ID
                           && a.Patient == p.ID
                           && a.Code.Contains(code)
                           select new
                           {
                               ID = a.ID,
                               Code = a.Code,
                               Patient = a.Patient,
                               PatientName = p.Name,
                               Doctor = d.ID,
                               DoctorName = d.Name,
                               Date = a.Date,
                               Time = a.Time,
                               Status = a.Status,
                               IsPayment = a.IsPayment,
                               Price = a.Price,
                               Reduce = a.Reduce,
                               Amount = a.Amount
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    var item = _lst.FirstOrDefault();
                    AppoinmentView view = new AppoinmentView();
                    view.Amount = item.Amount;
                    view.Code = item.Code;
                    view.Date = item.Date.ToString("dd/MM/yyyy");
                    view.Doctor = item.Doctor;
                    view.DoctorName = item.DoctorName;
                    view.ID = item.ID;
                    view.IsPayment = item.IsPayment;
                    view.Patient = item.Patient;
                    view.PatientName = item.PatientName;
                    view.Price = item.Price;
                    view.Reduce = item.Reduce;
                    view.Status = item.Status;
                    view.Time = item.Time;
                    return view;

                }
                return new AppoinmentView();
            }
            catch (Exception)
            {

                return new AppoinmentView();
            }
        }

        public IEnumerable<AppoinmentView> GetByDoctor(int id)
        {
            try
            {
                var _lst = from a in DbContext.Appoinments
                           from p in DbContext.Patients
                           from d in DbContext.Doctors
                           where a.Doctor == d.ID
                           && a.Patient == p.ID
                           && a.Doctor == id
                           select new
                           {
                               ID = a.ID,
                               Code = a.Code,
                               Patient = a.Patient,
                               PatientName = p.Name,
                               Doctor = d.ID,
                               DoctorName = d.Name,
                               Date = a.Date,
                               Time = a.Time,
                               Status = a.Status,
                               IsPayment = a.IsPayment,
                               Price = a.Price,
                               Reduce = a.Reduce,
                               Amount = a.Amount
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    List<AppoinmentView> appoinments = new List<AppoinmentView>();
                    foreach (var item in _lst)
                    {
                        AppoinmentView view = new AppoinmentView();
                        view.Amount = item.Amount;
                        view.Code = item.Code;
                        view.Date = item.Date.ToString("dd/MM/yyyy");
                        view.Doctor = item.Doctor;
                        view.DoctorName = item.DoctorName;
                        view.ID = item.ID;
                        view.IsPayment = item.IsPayment;
                        view.Patient = item.Patient;
                        view.PatientName = item.PatientName;
                        view.Price = item.Price;
                        view.Reduce = item.Reduce;
                        view.Status = item.Status;
                        view.Time = item.Time;
                        appoinments.Add(view);
                    }
                    return appoinments;
                }
                return new List<AppoinmentView>();
            }
            catch (Exception)
            {

                return new List<AppoinmentView>();
            }
        }

        public IEnumerable<AppoinmentView> GetByPatient(int id)
        {
            try
            {
                var _lst = from a in DbContext.Appoinments
                           from p in DbContext.Patients
                           from d in DbContext.Doctors
                           where a.Doctor == d.ID
                           && a.Patient == p.ID
                           && a.Patient == id
                           select new
                           {
                               ID = a.ID,
                               Code = a.Code,
                               Patient = a.Patient,
                               PatientName = p.Name,
                               Doctor = d.ID,
                               DoctorName = d.Name,
                               Date = a.Date,
                               Time = a.Time,
                               Status = a.Status,
                               IsPayment = a.IsPayment,
                               Price = a.Price,
                               Reduce = a.Reduce,
                               Amount = a.Amount
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    List<AppoinmentView> appoinments = new List<AppoinmentView>();
                    foreach (var item in _lst)
                    {
                        AppoinmentView view = new AppoinmentView();
                        view.Amount = item.Amount;
                        view.Code = item.Code;
                        view.Date = item.Date.ToString("dd/MM/yyyy");
                        view.Doctor = item.Doctor;
                        view.DoctorName = item.DoctorName;
                        view.ID = item.ID;
                        view.IsPayment = item.IsPayment;
                        view.Patient = item.Patient;
                        view.PatientName = item.PatientName;
                        view.Price = item.Price;
                        view.Reduce = item.Reduce;
                        view.Status = item.Status;
                        view.Time = item.Time;
                        appoinments.Add(view);
                    }
                    return appoinments;
                }
                return new List<AppoinmentView>();
            }
            catch (Exception)
            {

                return new List<AppoinmentView>();
            }
        }

        public bool UpdatePayment(long id)
        {
            try
            {
                var _item = DbContext.Appoinments.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.IsPayment = true;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateStatus(long id, int status)
        {
            try
            {
                var _item = DbContext.Appoinments.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    _item.Status = status;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
