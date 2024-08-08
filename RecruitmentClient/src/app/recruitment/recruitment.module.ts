import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecruitmentRoutingModule } from './recruitment-routing.module';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { RecruitProfileComponent } from './components/recruit-profile/recruit-profile.component';
import { PostJobComponent } from './components/post-job/post-job.component';
import { ManageJobsComponent } from './components/manage-jobs/manage-jobs.component';
import { ListCandidatesAppliedComponent } from './components/list-candidates-applied/list-candidates-applied.component';
import { RecruitmentComponent } from './recruitment.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [
    RecruitProfileComponent,
    PostJobComponent,
    ManageJobsComponent,
    ListCandidatesAppliedComponent,
    RecruitmentComponent,
  ],
  imports: [
    CommonModule,
    CKEditorModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
    RecruitmentRoutingModule,
    PaginationModule.forRoot(),
  ],
})
export class RecruitmentModule {}
