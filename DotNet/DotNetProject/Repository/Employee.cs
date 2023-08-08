using DotNetProject.Models;
using DotNetProject.Request_Model;
using DotNetProject.Response_Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetProject.Repository
{
    public class Employee : IEmployee
    {
        private sdirectdbContext _dbContext;
        public Employee(sdirectdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<GetRequestDto> GetAllEmployeeList()
        {
            ResponseModel objresponseModel = new ResponseModel();
            List<GetRequestDto> objGetRequestDto = new List<GetRequestDto>();
            var obj = (from emp in _dbContext.AstitvaEmployees2904s
                       join deg in _dbContext.AstitvaDesignation2904s on emp.DesignationId equals deg.DesignationId
                       join dep in _dbContext.AstitvaDepartment2904s on emp.DepartmentId equals dep.DepartmentId
                       where emp.IsActive == true && emp.IsDeleted == false
                       select new GetRequestDto
                       {
                           EmployeeNumber = emp.EmployeeNumber,
                           EmployeeId = emp.EmployeeId,
                           EmployeeName = emp.EmployeeName,
                           CompanyName = emp.CompanyName,
                           CompanyAddress = emp.CompanyAddress,
                           Month = emp.Month,
                           Year = emp.Year,
                           Doj = emp.Doj,
                           DepartmentId = dep.DepartmentId,
                           Department = dep.Department,
                           DesignationId = deg.DesignationId,
                           Designation = deg.Designation,
                           Uan = emp.Uan,
                           Pfno = emp.Pfno,
                           BankName = dep.Department,
                           AccountNo = emp.AccountNo,
                           Esino = emp.Esino,
                           BasicWages = emp.BasicWages,
                           Hra = emp.Hra,
                           Epf = emp.Epf,
                           Esi = emp.Esi,
                           TotalEarning = emp.TotalEarning,
                           TotalDeduction = emp.TotalDeduction,
                           NetSalary = emp.NetSalary,
                           IsActive = emp.IsActive,
                           IsDeleted = emp.IsDeleted,
                           CreatedBy = emp.CreatedBy,
                           CreatedDate = emp.CreatedDate,
                       }).ToList();
            objGetRequestDto = obj;
            return objGetRequestDto;
        }

        public List<GetAllDesignationDto> GetAllDesignationList()
        {
            List<GetAllDesignationDto> objGetAllDesignationDto = new List<GetAllDesignationDto>();
            var obj = (from deg in _dbContext.AstitvaDesignation2904s
                       select new GetAllDesignationDto
                       {
                           DesignationId = deg.DesignationId,
                           Designation = deg.Designation,
                       }).ToList();
            objGetAllDesignationDto = obj;
            return objGetAllDesignationDto;
            
        }

        public List<GetAllDepartmentDto> GetAllDepartmentList()
        {
            {
                List<GetAllDepartmentDto> objGetAllDepartmentDto = new List<GetAllDepartmentDto>();
                var obj = (from deg in _dbContext.AstitvaDepartment2904s
                           select new GetAllDepartmentDto
                           {
                               DepartmentId = deg.DepartmentId,
                               Department = deg.Department,
                           }).ToList();
                objGetAllDepartmentDto = obj;
                return objGetAllDepartmentDto;

            }
        }

        public AstitvaEmployees2904 GetEmpByEmpId(string id)
        {
            try
            {
                var DataById = _dbContext.AstitvaEmployees2904s.FirstOrDefault(l => l.EmployeeId == id);
                return DataById;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public SalarySlipDataModel viewSalarySlipdata(string EmployeeId)
        {
            SalarySlipDataModel objSalarySlipDataModel = new SalarySlipDataModel();

            var obj = (from emp in _dbContext.AstitvaEmployees2904s
                   join deg in _dbContext.AstitvaDesignation2904s on emp.DesignationId equals deg.DesignationId
                   join dep in _dbContext.AstitvaDepartment2904s on emp.DepartmentId equals dep.DepartmentId
                       where  emp.EmployeeId== EmployeeId
                       select new SalarySlipDataModel
                   {
                       EmployeeId = emp.EmployeeId,
                       EmployeeName = emp.EmployeeName,
                       CompanyName = emp.CompanyName,
                       CompanyAddress = emp.CompanyAddress,
                       Month = emp.Month,
                       Year = emp.Year,
                       Doj = emp.Doj,
                       Designation = deg.Designation,
                       Department = dep.Department,
                       Uan = emp.Uan,
                       Pfno = emp.Pfno,
                       BankName = emp.BankName,
                       Esino = emp.Esino,
                       AccountNo = emp.AccountNo,
                       BasicWages = emp.BasicWages,
                       Epf = emp.Epf,
                       Hra = emp.Hra,
                       Esi = emp.Esi,
                       TotalDeduction = emp.TotalDeduction,
                       TotalEarning = emp.TotalEarning,
                       NetSalary = emp.NetSalary
                   }).FirstOrDefault();
            objSalarySlipDataModel = obj;
            //ObjResponse.ResponseMessage = "Success";
            //ObjResponse.StatusCode = "200";
            //ObjResponse.viewSalarySlipModel = obj;
            return objSalarySlipDataModel;
        }

        public ResponseModel AddEmployee(PostEmployeeRequest postemployee)
        {
            ResponseModel objResponseModel = new ResponseModel();
            var chek = _dbContext.AstitvaEmployees2904s.FirstOrDefault(l => l.EmployeeName == postemployee.EmployeeName && l.BankName == postemployee.BankName && l.AccountNo == postemployee.AccountNo);
            if (chek != null)
            {
                objResponseModel.ResponseCode = "400";
                objResponseModel.StatusCode = "Bad Request";
                objResponseModel.ResponseMessage = "Employee Already Exist.";
                return objResponseModel;
            }
            else
            {
                //Connection string ---
                var builder = WebApplication.CreateBuilder();
                var conString = builder.Configuration.GetConnectionString("AppConnectionString");
                SqlConnection con = new SqlConnection(conString);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                // Calling SP

                SqlCommand cmd = new SqlCommand("SPAstitvaEmployees2904_SaveEmployee ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = postemployee.EmployeeId;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = postemployee.EmployeeName;
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = postemployee.CompanyName;
                cmd.Parameters.Add("@CompanyAddress", SqlDbType.VarChar).Value = postemployee.CompanyAddress;
                cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = postemployee.Month;
                cmd.Parameters.Add("@Year", SqlDbType.Int).Value = postemployee.Year;
                cmd.Parameters.Add("@DOJ", SqlDbType.Date).Value = postemployee.Doj;
                cmd.Parameters.Add("@DesignationId", SqlDbType.Int).Value = postemployee.DesignationId;
                cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = postemployee.DepartmentId;
                cmd.Parameters.Add("@UAN", SqlDbType.VarChar).Value = postemployee.Uan;
                cmd.Parameters.Add("@PFNo", SqlDbType.VarChar).Value = postemployee.Pfno;
                cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = postemployee.BankName;
                cmd.Parameters.Add("@AccountNo", SqlDbType.Int).Value = postemployee.AccountNo;
                cmd.Parameters.Add("@ESINo", SqlDbType.Int).Value = postemployee.Esino;
                cmd.Parameters.Add("@BasicWages", SqlDbType.Decimal).Value = postemployee.BasicWages;
                cmd.Parameters.Add("@HRA", SqlDbType.Decimal).Value = postemployee.Hra;
                //cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = postemployee.IsActive;
                //cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = postemployee.IsDeleted;
                //cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = postemployee.CreatedBy;
                //cmd.Parameters.Add("@CreatedDate", SqlDbType.Date).Value = postemployee.CreatedDate;
                int iReturn = cmd.ExecuteNonQuery();
                con.Close();
                if (iReturn > 0)
                {
                    objResponseModel.ResponseCode = "200";
                    objResponseModel.StatusCode = "Success";
                    objResponseModel.ResponseMessage = "Emloyee Added successfully.";
                    return objResponseModel;
                }
                else
                {
                    objResponseModel.ResponseCode = "404";
                    objResponseModel.StatusCode = "Failed";
                    objResponseModel.ResponseMessage = "Emloyee NOT Added";
                    return objResponseModel;
                }

            }
        }

        public ResponseModel UpdateEmployee(RequestModelForPut REFRequestModelForPut)
        {
            ResponseModel objResponseModel = new ResponseModel();
            //Connection string ---
            var builder = WebApplication.CreateBuilder();
            var conString = builder.Configuration.GetConnectionString("AppConnectionString");
            SqlConnection con = new SqlConnection(conString);
            if (con.State == ConnectionState.Closed)
                con.Open();

            // Calling SP

            SqlCommand cmd = new SqlCommand("SPAstitvaEmployees2904_UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = REFRequestModelForPut.EmployeeId;
            cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = REFRequestModelForPut.EmployeeName;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar).Value = REFRequestModelForPut.CompanyName;
            cmd.Parameters.Add("@CompanyAddress", SqlDbType.VarChar).Value = REFRequestModelForPut.CompanyAddress;
            cmd.Parameters.Add("@Month", SqlDbType.VarChar).Value = REFRequestModelForPut.Month;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = REFRequestModelForPut.Year;
            cmd.Parameters.Add("@DOJ", SqlDbType.Date).Value = REFRequestModelForPut.Doj;
            cmd.Parameters.Add("@DesignationId", SqlDbType.Int).Value = REFRequestModelForPut.DesignationId;
            cmd.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = REFRequestModelForPut.DepartmentId;
            cmd.Parameters.Add("@UAN", SqlDbType.VarChar).Value = REFRequestModelForPut.Uan;
            cmd.Parameters.Add("@PFNo", SqlDbType.VarChar).Value = REFRequestModelForPut.Pfno;
            cmd.Parameters.Add("@BankName", SqlDbType.VarChar).Value = REFRequestModelForPut.BankName;
            cmd.Parameters.Add("@AccountNo", SqlDbType.Int).Value = REFRequestModelForPut.AccountNo;
            cmd.Parameters.Add("@ESINo", SqlDbType.Int).Value = REFRequestModelForPut.Esino;
            cmd.Parameters.Add("@BasicWages", SqlDbType.Decimal).Value = REFRequestModelForPut.BasicWages;
            cmd.Parameters.Add("@HRA", SqlDbType.Decimal).Value = REFRequestModelForPut.Hra;
            //cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = REFRequestModelForPut.IsActive;
            //cmd.Parameters.Add("@IsDeleted", SqlDbType.Bit).Value = REFRequestModelForPut.IsDeleted;
            int iReturn = cmd.ExecuteNonQuery();
            con.Close();
            if (iReturn > 0)
            {
                objResponseModel.ResponseCode = "OK";
                objResponseModel.StatusCode = "200";
                objResponseModel.ResponseMessage = "Record Update successfully.";
                return objResponseModel;
            }
            else
            {
                objResponseModel.ResponseCode = "Error";
                objResponseModel.ResponseMessage = "Record not updated.";
                return objResponseModel;
            }
        }

        public ResponseModel DeleteEmpByEmpId(string id)
        {
            ResponseModel objResponseModel = new ResponseModel();
            var newData = _dbContext.AstitvaEmployees2904s.FirstOrDefault(l => l.EmployeeId == id);
            if (newData != null)
            {
                newData.IsActive = false;
                newData.IsDeleted = true;

                _dbContext.SaveChanges();
                objResponseModel.ResponseCode = "OK";
                objResponseModel.StatusCode = "200";
                objResponseModel.ResponseMessage = "Record Delete successfully.";
                return objResponseModel;
            }
            else
            {
                objResponseModel.ResponseCode = "Error";
                objResponseModel.ResponseMessage = "Record not Deleted.";
                return objResponseModel;
            }
        }
    }
}
