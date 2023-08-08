import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { DataSource } from '@angular/cdk/collections';
import { Observable, ReplaySubject } from 'rxjs';
import { Router } from '@angular/router'
import { ApiService } from '../services/api.service';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { SalarySlipComponent } from '../salary-slip/salary-slip.component';
import { PutComponent } from '../put/put.component';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-show',
  templateUrl: './show.component.html',
  styleUrls: ['./show.component.css']
})
export class ShowComponent {
  val: any = []
  Users: any = []
  dataSource: any;
  displayedColumns: string[] = ['Employee Id', 'Employee Name', 'CompanyName', 'Designation', 'DOJ', 'Edit', 'Delete', 'ViewSalarySlip'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private ServiceCall: ApiService, private route: Router, private _Dialog: MatDialog, private snackBar: MatSnackBar) { }
  ngOnInit() {
    this.ServiceCall.GetALLEmployeeListApi().subscribe((res: any) => {
      if (res != null) {
        this.dataSource = new MatTableDataSource<any>(res);
        console.log(res)
      }
    })
  }


  deleteOnClick(id: any) {
   
    console.warn(id);
    if(confirm("Are you sure to delete ?"))
    {
      this.ServiceCall.DeleteEmpByEmpIdApi(id).subscribe(res => {
        this.snackBar.open('Delete Successfully....','Undo', {
          duration:99000
        });
        location.reload();
      });
    }


    // --------------------------- OR WE CAN DO IT BY FOLLOWING CODE --------------------------------
    // this.ServiceCall.DeleteEmpByEmpIdApi(id).subscribe(res => {
    //   alert('Employee Deleted Successfully....')
    //   console.log(id);
    // });
    // location.reload();

  }

  
  getDataById(id: any) {

    this._Dialog.open(PutComponent,  { data: id } )
  }

  ViewDetails(id: any) {
    this._Dialog.open(SalarySlipComponent, { data: id } )
  }
}
