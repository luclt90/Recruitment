import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { RecruitProfileComponent } from './components/recruit-profile/recruit-profile.component';
import { PostJobComponent } from './components/post-job/post-job.component';
import { ManageJobsComponent } from './components/manage-jobs/manage-jobs.component';
import { RecruitmentComponent } from './recruitment.component';

const routes: Routes = [
  {
    path: '',
    component: RecruitmentComponent,
    children: [
      {
        path: 'ho-so-cong-ty',
        component: RecruitProfileComponent,
      },
      {
        path: 'dang-tin',
        component: PostJobComponent,
      },
      {
        path: 'danh-sach-cong-viec',
        component: ManageJobsComponent,
      },
      {
        path: '',
        redirectTo: 'ho-so-cong-ty',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RecruitmentRoutingModule {}
