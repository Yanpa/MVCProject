using CourseProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Services
{
    public interface IAppointmentServices
    {
        public List<Doctor> GetDoctorList();
        public List<Patient> GetPatientList();
        public Task<int> AddUpdate(AppointmentVM model);
    }
}
