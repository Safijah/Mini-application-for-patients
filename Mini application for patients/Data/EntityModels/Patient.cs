using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.EntityModels
{
   public  class Patient
    {
        [Key, ForeignKey("User")]
        public string ID { get; set; }

        public virtual User User { get; set; }
    }
}
