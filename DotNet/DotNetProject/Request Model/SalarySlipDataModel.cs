namespace DotNetProject.Request_Model
{
    public class SalarySlipDataModel
    {
        public string EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Month { get; set; }
        public int? Year { get; set; }
        public DateTime Doj { get; set; }
        public string Designation { get; set; }
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
    }
}
