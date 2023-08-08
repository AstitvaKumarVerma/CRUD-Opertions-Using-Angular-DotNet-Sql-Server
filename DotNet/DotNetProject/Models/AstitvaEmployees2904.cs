using System;
using System.Collections.Generic;

namespace DotNetProject.Models
{
    public partial class AstitvaEmployees2904
    {
        public string? Prefix { get; set; }
        public int EmployeeNumber { get; set; }
        public string? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Month { get; set; }
        public int? Year { get; set; }
        public DateTime Doj { get; set; }
        public int DesignationId { get; set; }
        public int DepartmentId { get; set; }
        public string? Uan { get; set; }
        public string? Pfno { get; set; }
        public string BankName { get; set; } = null!;
        public int AccountNo { get; set; }
        public int Esino { get; set; }
        public decimal BasicWages { get; set; }
        public decimal Hra { get; set; }
        public decimal? Epf { get; set; }
        public decimal? Esi { get; set; }
        public decimal? TotalEarning { get; set; }
        public decimal? TotalDeduction { get; set; }
        public decimal? NetSalary { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual AstitvaDepartment2904 Department { get; set; } = null!;
        public virtual AstitvaDesignation2904 Designation { get; set; } = null!;
    }
}
