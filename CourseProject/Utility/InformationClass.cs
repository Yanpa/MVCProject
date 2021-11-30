using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Utility
{
    public class InformationClass
    {
        public static string Admin = "Admin";
        public static string Patient = "Patient";
        public static string Doctor = "Doctor";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = InformationClass.Admin, Text=InformationClass.Admin},
                new SelectListItem{Value = InformationClass.Patient, Text=InformationClass.Patient},
                new SelectListItem{Value = InformationClass.Doctor, Text=InformationClass.Doctor}
            };
        }
    }
}
