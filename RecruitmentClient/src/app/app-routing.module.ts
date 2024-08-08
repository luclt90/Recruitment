import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppliedJobsComponent } from './candidate/components/applied-jobs/applied-jobs.component';
import { HomeComponent } from './pages/home/home.component';
import { JobsComponent } from './pages/jobs/jobs.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {
    path: 'viec-lam',
    component: JobsComponent,
  },
  { path: 'appliedJobs', component: AppliedJobsComponent },
  {
    path: 'nha-tuyen-dung',
    loadChildren: () =>
      import('./recruitment/recruitment.module').then(
        (m) => m.RecruitmentModule
      ),
  },
  {
    path: 'ung-vien',
    loadChildren: () =>
      import('./candidate/candidate.module').then((m) => m.CandidateModule),
  },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
