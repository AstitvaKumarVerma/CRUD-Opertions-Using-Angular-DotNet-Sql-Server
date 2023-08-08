using DotNetProject.Repository;
using DotNetProject.Request_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _IEmployee;
        public EmployeeController(IEmployee IEmployee)
        {
            _IEmployee = IEmployee;
        }


        [HttpGet]
        [Route("GetALLEmployeeList")]

        public IActionResult GetAllEmployeeList()
        {
            var data = _IEmployee.GetAllEmployeeList();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetALLDesignationList")]

        public IActionResult GetEmployee()
        {
            var data = _IEmployee.GetAllDesignationList();
            return Ok(data);
        }


        [HttpGet]
        [Route("GetAllDepartmentList")]

        public IActionResult GetAllDepartmentList()
        {
            var data = _IEmployee.GetAllDepartmentList();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetEmpByEmpId")]
        public IActionResult GetEmpByEmpId(string id)
        {
            var data = _IEmployee.GetEmpByEmpId(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("ViewSalarySlipData")]

        public IActionResult viewSalarySlipdata(string EmployeeId)
        {
            var data = _IEmployee.viewSalarySlipdata(EmployeeId);
            return Ok(data);
        }


        [HttpPost]
        [Route("PostEmployeeeThroughSP")]
        public IActionResult PostEmp([FromBody] PostEmployeeRequest refpostemployee)
        {
            var data = _IEmployee.AddEmployee(refpostemployee);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateEmpThroughSP")]
        public IActionResult UpdateEmp([FromBody] RequestModelForPut REFRequestModelForPut)
        {
            var data = _IEmployee.UpdateEmployee(REFRequestModelForPut);
            return Ok(data);
        }


        [HttpDelete]
        [Route("DeleteEmpByEmpId")]
        public IActionResult DeleteEmpByEmpId(string id)
        {
            var data = _IEmployee.DeleteEmpByEmpId(id);
            return Ok(data);
        }
    }
}
