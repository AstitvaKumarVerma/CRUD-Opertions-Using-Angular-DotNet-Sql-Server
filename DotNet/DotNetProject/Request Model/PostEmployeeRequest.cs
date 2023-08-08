using DotNetProject.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetProject.Request_Model
{
    public class PostEmployeeRequest
    {
        //[Required(ErrorMessage = "Employee ID is Required")]
        //public string? EmployeeId { get; set; }

        [Required(ErrorMessage ="Employee Name is Required")]
        public string? EmployeeName { get; set; }

        [Required(ErrorMessage = "CompanyName is Required")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "CompanyAddress is Required")]
        public string? CompanyAddress { get; set; }

        [Required(ErrorMessage = "Month is Required")]
        public string? Month { get; set; }

        [Required(ErrorMessage = "Year is Required")]
        public int? Year { get; set; }
        public DateTime Doj { get; set; }

        [Required(ErrorMessage = "DesignationId is Required")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "DepartmentId is Required")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Uan is Required")]
        public string? Uan { get; set; }

        [Required(ErrorMessage = "PFno is Required")]
        public string? Pfno { get; set; }

        [Required(ErrorMessage = "BankName is Required")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "AccountNo is Required")]
        public int AccountNo { get; set; }

        [Required(ErrorMessage = "Esino is Required")]
        public int Esino { get; set; }

        [Required(ErrorMessage = "BasicWages is Required")]
        public decimal BasicWages { get; set; }

        [Required(ErrorMessage = "Hra is Required")]
        public decimal Hra { get; set; }
        [DefaultValue("true")]
        public bool? IsActive { get; set; }
        [DefaultValue("SDD")]
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }
    }
}
