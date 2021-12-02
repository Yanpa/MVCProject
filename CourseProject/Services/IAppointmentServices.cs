using CourseProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Services
{
    interface IAppointmentServices
    {
        public List<Doctor> GetDoctorList();
        public List<Patient> GetPatientList();
    }
}
