import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { ApiService } from '../services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { formatDate } from '@angular/common';
import { MatSnackBar } from '@angular/material/snack-bar';
@Component({
  selector: 'app-put',
  templateUrl: './put.component.html',
  styleUrls: ['./put.component.css']
})
export class PutComponent {
  UpdateEmployeeForm!:FormGroup

  constructor(private _Dialog:MatDialog,private ServiceCall: ApiService, private formbuilder:FormBuilder, private router:ActivatedRoute, private snackBar: MatSnackBar, @Inject(MAT_DIALOG_DATA) public data:any) { }
  userID!: number;
  ngOnInit(): void {
    this.UpdateEmployeeForm=new FormGroup({
      employeeId: new FormControl('',[Validators.required]),
      employeeName: new FormControl('',[Validators.required]),
      companyName: new FormControl('',[Validators.required]),
      companyAddress: new FormControl('',[Validators.required]),
      month: new FormControl('',[Validators.required]),
      year: new FormControl('',[Validators.required]),
      doj: new FormControl(''),
      designationId: new FormControl('',[Validators.required]),
      departmentId: new FormControl('',[Validators.required]),
      uan: new FormControl('',[Validators.required]),
      pfno: new FormControl('',[Validators.required]),
      bankName: new FormControl('',[Validators.required]),
      accountNo: new FormControl('',[Validators.required,Validators.minLength(8),Validators.maxLength(8)]),
      esino: new FormControl('',[Validators.required,Validators.minLength(9),Validators.maxLength(9)]),
      basicWages: new FormControl('',[Validators.required]),
      hra: new FormControl('',[Validators.required])
      });

          this.userID = this.data
          console.warn("check", this.userID);
        
      this.getDataById(this.userID);
  }
  
  UpdateEmployee(data:any){
    console.log(this.UpdateEmployeeForm.value);

    if(confirm("Are you sure to Update ?"))
    {
      console.warn("update k time");
      
      this.ServiceCall.PutApi(data).subscribe((res:any) => {
        this.snackBar.open('Update Successfully....','Undo', {
          duration:99000
        });
        console.warn(res);
        location.reload();
      });
    }

    // --------------------------- OR WE CAN DO IT BY FOLLOWING CODE --------------------------------
    // this.ServiceCall.PutApi(data).subscribe((res:any) => {
    //   alert("Update Successful");
    //   console.warn(res);
    //   location.reload();
    //   });
  }

  year:any;
  getDataById(id:any)
  {
    debugger
    this.userID = id;
    this.ServiceCall.GetEmpByEmpId(this.userID).subscribe((res:any)=>{
      this.UpdateEmployeeForm.patchValue(res)
      this.UpdateEmployeeForm.controls['departmentId'].setValue(String(res.departmentId));
      this.UpdateEmployeeForm.controls['designationId'].setValue(String(res.designationId));
      this.UpdateEmployeeForm.controls['year'].setValue(String(res.year));


      // this.UpdateEmployeeForm.controls['isActive'].setValue(String(res.isActive));
      // this.UpdateEmployeeForm.controls['isDeleted'].setValue(String(res.isDeleted));
      // this.UpdateEmployeeForm.patchValue({empDob:formatDate})
      console.warn("res", res);
      
    })
  }

  cancelButton(){
    this._Dialog.closeAll();
    location.reload();
  }
}
