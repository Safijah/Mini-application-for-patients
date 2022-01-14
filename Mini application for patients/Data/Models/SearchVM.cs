using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class SearchVM
    {
        public string PatientID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
