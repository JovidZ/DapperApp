using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public DateTime birthDate { get; set; }
        public int gender { get; set; }
        public DateTime hireDate { get; set; }

    }

    public class EmployeeId
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }

}
