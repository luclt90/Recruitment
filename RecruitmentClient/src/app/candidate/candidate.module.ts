import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CandidateRoutingModule } from './candidate-routing.module';
import { CandidateComponent } from './candidate.component';
import { AppliedJobsComponent } from './components/applied-jobs/applied-jobs.component';
import { CandidateProfileComponent } from './components/candidate-profile/candidate-profile.component';


@NgModule({
  declarations: [
    CandidateComponent,
    AppliedJobsComponent,
    CandidateProfileComponent,
  ],
  imports: [
    CommonModule,
    CandidateRoutingModule
  ]
})
export class CandidateModule { }
