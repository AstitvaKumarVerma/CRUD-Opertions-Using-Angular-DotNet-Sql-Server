import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PostComponent } from '../post/post.component';
import { ApiService } from '../services/api.service';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-my-nav',
  templateUrl: './my-nav.component.html',
  styleUrls: ['./my-nav.component.css']
})
export class MyNavComponent {
  constructor(private _Dialog:MatDialog) { }
  OpenAddUpdateForm()
  {
    this._Dialog.open(PostComponent)
  }
}
