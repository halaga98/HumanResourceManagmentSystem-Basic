using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp8
{
    public class Employee
    {
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string FavLang { get; set; }
        public List<EmployeeCertificate> Certificates { get; set; }
        public Employee()
        {
            this.Certificates = new List<EmployeeCertificate>();
        }
        
    }
    public class EmployeeCertificate
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
