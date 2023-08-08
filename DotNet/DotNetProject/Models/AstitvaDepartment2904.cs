using System;
using System.Collections.Generic;

namespace DotNetProject.Models
{
    public partial class AstitvaDepartment2904
    {
        public AstitvaDepartment2904()
        {
            AstitvaEmployees2904s = new HashSet<AstitvaEmployees2904>();
        }

        public int DepartmentId { get; set; }
        public string? Department { get; set; }

        public virtual ICollection<AstitvaEmployees2904> AstitvaEmployees2904s { get; set; }
    }
}
