using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class GetPatientsVM
    {
        public string PatientID { get; set; }
        public List<SelectListItem> Patients { get; set; }
    }
}
