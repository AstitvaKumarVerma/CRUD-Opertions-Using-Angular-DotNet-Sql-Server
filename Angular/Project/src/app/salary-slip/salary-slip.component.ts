import { Component, Inject, Input, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-salary-slip',
  templateUrl: './salary-slip.component.html',
  styleUrls: ['./salary-slip.component.css']
})
export class SalarySlipComponent implements OnInit {
  Val: any;
  userID: any;
  constructor(private ServiceCall: ApiService, private route: Router, private router: ActivatedRoute, private dialogRef: MatDialogRef<SalarySlipComponent>, @Inject(MAT_DIALOG_DATA) public data:any) { }
  ngOnInit(): void {

      this.userID = this.data;
      console.warn("check", this.userID);

  
    this.GetById(this.userID)
  }
  GetById(id: any) {
    id = this.userID
    this.ServiceCall.ViewSalaryDataApi(this.userID).subscribe(res => {
      this.Val = res;
      console.warn(this.Val);
    })
  }

  public openPDF(): void {
    let DATA: any = document.getElementById('htmlData');
    html2canvas(DATA).then((canvas) => {
      let fileWidth = 150;
      let fileHeight = 115;
      // let fileHeight = (canvas.height * fileWidth) / canvas.width;
      const FILEURI = canvas.toDataURL('image/png');
      let PDF = new jsPDF('p', 'mm', 'a4');
      let positionTop = 20;
      PDF.addImage(FILEURI, 'PNG', 0, positionTop, fileWidth, fileHeight);
      PDF.save(this.Val.employeeName+'.pdf');
    });
  }

  OkButton() {
    this.dialogRef.close();
  }
}
