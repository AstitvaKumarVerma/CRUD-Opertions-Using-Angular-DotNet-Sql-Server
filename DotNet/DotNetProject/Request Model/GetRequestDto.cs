using DotNetProject.Models;

namespace DotNetProject.Request_Model
{
    public class GetRequestDto
    {
        public int EmployeeNumber { get; set; }
        public string EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Month { get; set; }
        public int? Year { get; set; }
        public DateTime Doj { get; set; }
        public int DesignationId { get; set; }
        public string Designation { get; set; } 
        public int DepartmentId { get; set; }
        public string Department { get; set; } 
        public string? Uan { get; set; }
        public string? Pfno { get; set; }
        public string BankName { get; set; } 
        public long AccountNo { get; set; }
        public long Esino { get; set; }
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
        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        
    }
}
