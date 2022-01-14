using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_application_for_patients.Models
{
    public class GetAppointmentVM
    {
        public class Lista
        {

            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Date { get; set; }
        }
        public List<Lista> Appointment { get; set; }
        public string PatientID { get; set; }
        public List<SelectListItem> Patients { get; set; }
        public DateTime DateFrom  { get; set; }
        public DateTime DateTo  { get; set; }
        public string Note { get; set; }
    }
}
