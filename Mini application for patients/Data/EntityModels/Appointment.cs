using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
{
   public  class Appointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}
