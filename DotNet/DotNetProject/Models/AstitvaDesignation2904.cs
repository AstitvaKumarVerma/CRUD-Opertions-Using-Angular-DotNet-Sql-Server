using System;
using System.Collections.Generic;

namespace DotNetProject.Models
{
    public partial class AstitvaDesignation2904
    {
        public AstitvaDesignation2904()
        {
            AstitvaEmployees2904s = new HashSet<AstitvaEmployees2904>();
        }

        public int DesignationId { get; set; }
        public string? Designation { get; set; }

        public virtual ICollection<AstitvaEmployees2904> AstitvaEmployees2904s { get; set; }
    }
}
