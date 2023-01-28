using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_tracker.domain.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public decimal Pay_Rate { get; set; }
        public DateTime Hired_at { get; set; } = DateTime.Now;
    }
}
