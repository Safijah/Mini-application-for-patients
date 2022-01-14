using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityModels
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
    }
}
