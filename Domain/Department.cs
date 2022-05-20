﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DepartmentId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }

        public string ManagerFullName { get; set; }
    }
}