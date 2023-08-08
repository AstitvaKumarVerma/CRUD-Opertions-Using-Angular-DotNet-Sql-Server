import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http:HttpClient) { }
  GetALLEmployeeListApi()
  {
    return this.http.get<any>('https://localhost:7278/api/Employee/GetALLEmployeeList');
  }

  GetALLDesignationListApi()
  {
    return this.http.get<any>('https://localhost:7278/api/Employee/GetALLDesignationList');
  }

  GetAllDepartmentList()
  {
    return this.http.get<any>('https://localhost:7278/api/Employee/GetAllDepartmentList');
  }

  PostApi(a:any)
  {
    return this.http.post('https://localhost:7278/api/Employee/PostEmployeeeThroughSP',a);
  }

  PutApi(x:any)
  {
    debugger
    return this.http.put<any>('https://localhost:7278/api/Employee/UpdateEmpThroughSP',x);
  }

  GetEmpByEmpId(val:any)
  {
    return this.http.get('https://localhost:7278/api/Employee/GetEmpByEmpId?id='+ val);
  }

  ViewSalaryDataApi(val:any)
  {
    return this.http.get('https://localhost:7278/api/Employee/ViewSalarySlipData?EmployeeId='+ val);
  }
  
  DeleteEmpByEmpIdApi(val:any)
  {
    return this.http.delete('https://localhost:7278/api/Employee/DeleteEmpByEmpId?id='+ val);
  }
}
