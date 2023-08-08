import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyNavComponent } from './my-nav/my-nav.component';
import { ShowComponent } from './show/show.component';
import { PostComponent } from './post/post.component';
import { PutComponent } from './put/put.component';
import { SalarySlipComponent } from './salary-slip/salary-slip.component';

const routes: Routes = [
  {
    path:'myNav',
    component: MyNavComponent
  },
  {
    path:'show',
    component: ShowComponent
  },
  {
    path:'post',
    component: PostComponent
  },
  {
    path:'salarySlip',
    component: SalarySlipComponent
  },
  {
    path:'put',
    component: PutComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
