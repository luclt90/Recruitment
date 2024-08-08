import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateComponent } from './candidate.component';
import { AppliedJobsComponent } from './components/applied-jobs/applied-jobs.component';
import { CandidateProfileComponent } from './components/candidate-profile/candidate-profile.component';

const routes: Routes = [
  {
    path: '',
    component: CandidateComponent,
    children: [
      {
        path: 'ho-so',
        component: CandidateProfileComponent,
      },
      {
        path: 'cong-viec',
        component: AppliedJobsComponent,
      },
      {
        path: '',
        redirectTo: 'ho-so',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CandidateRoutingModule {}
