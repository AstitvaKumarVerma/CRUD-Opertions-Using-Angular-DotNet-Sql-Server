using DotNetProject.Models;
using DotNetProject.Request_Model;
using DotNetProject.Response_Model;

namespace DotNetProject.Repository
{
    public interface IEmployee
    {
        public List<GetRequestDto> GetAllEmployeeList();
        public List<GetAllDesignationDto> GetAllDesignationList();
        public List<GetAllDepartmentDto> GetAllDepartmentList();
        public AstitvaEmployees2904 GetEmpByEmpId(string id);
        public SalarySlipDataModel viewSalarySlipdata(string EmployeeId);
        public ResponseModel AddEmployee(PostEmployeeRequest REFpostemployee);
        public ResponseModel UpdateEmployee(RequestModelForPut REFRequestModelForPut);
        public ResponseModel DeleteEmpByEmpId(string id);
    }
}
