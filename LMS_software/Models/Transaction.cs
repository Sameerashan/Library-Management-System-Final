using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_software.Models
{
    public class Transaction
    {
        public string Timestamp { get; set; }
        public string StudentID { get; set; }
        public string ISBN { get; set; }
        public string Type { get; set; }
    }
}
