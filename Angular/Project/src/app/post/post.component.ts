import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements Validators, OnInit{
  AddEmployee=new FormGroup({
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
  constructor(private _Dialog:MatDialog, private ServiceCall: ApiService, private route: Router,private formBuilder:FormBuilder) { }
  ngOnInit(): void {

  }
  
  SaveEmployee(data:any)
  {
    console.log(data);
    this.ServiceCall.PostApi(data).subscribe(res => {
    alert("Data Add Successfully");
    console.log(data);

    location.reload();
    });
  }

  CancelButton(){
    this._Dialog.closeAll();
  }
}
