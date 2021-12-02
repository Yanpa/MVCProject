using CourseProject.Models;
using CourseProject.Models.ViewModels;
using CourseProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly ApplicationDbContext _db;

        public AppointmentServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddUpdate(AppointmentVM model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));

            if (model != null && model.Id > 0)
            {
                //update
                return 1;
            }
            else
            {
                //create
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    IsDoctorApproved = false,
                    AdminId = model.AdminId
                };

                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }
        }

        List<Doctor> IAppointmentServices.GetDoctorList()
        {
            var doctors = (from user in _db.Users
                           join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                           join roles in _db.Roles.Where(x => x.Name == InformationClass.Doctor) on userRoles.RoleId equals roles.Id
                           select new Doctor
                           {
                               Id = user.Id,
                               Name = user.Name
                           }).ToList();

            return doctors;
        }

        List<Patient> IAppointmentServices.GetPatientList()
        {
            var patients = (from user in _db.Users
                           join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                           join roles in _db.Roles.Where(x => x.Name == InformationClass.Patient) on userRoles.RoleId equals roles.Id
                           select new Patient
                           {
                               Id = user.Id,
                               Name = user.Name
                           }).ToList();

            return patients;
        }
    }
}
