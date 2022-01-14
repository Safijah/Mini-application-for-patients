using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_application_for_patients.Models
{
    public class AppointmentVM
    {
        public string PatientID { get; set; }
        public List<SelectListItem> Patients { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }
    }
}
