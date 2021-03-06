using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ResultVM
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
