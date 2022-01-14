using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class AddAppointmentVM
    {
        public string PatientID { get; set; }
        public List<SelectListItem> Patients { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Note { get; set; }
    }
}
