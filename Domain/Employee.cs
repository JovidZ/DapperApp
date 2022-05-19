using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public  class Employee
    {
        public int Id { get; set; }
        public string? firstname { get; set; }
        public string? lastName { get; set; }
        public DateTime? birthdate { get; set; }
        public DateTime hireDate { get; set; }  
        public int gender { get;  set; }


    }
    public class GetEmployee
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

}
