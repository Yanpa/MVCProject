using CourseProject.Services;
using CourseProject.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentServices _appointmentServices;

        public AppointmentController(IAppointmentServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
        }
        public IActionResult Index()
        {
            ViewBag.Duration = InformationClass.GetTimeDropDown();
            ViewBag.DoctorList = _appointmentServices.GetDoctorList();
            ViewBag.PatientList = _appointmentServices.GetPatientList();
            return View();
        }
    }
}
