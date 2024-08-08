import { Component, OnInit } from '@angular/core';
import { Pagination } from 'src/app/_models/pagination';
import { RecruitJobDetail } from 'src/app/_models/recruit-job-detail';
import { RecruitService } from 'src/app/_services/recruit.service';

@Component({
  selector: 'app-manage-jobs',
  templateUrl: './manage-jobs.component.html',
  styleUrls: ['./manage-jobs.component.css'],
})
export class ManageJobsComponent implements OnInit {
  jobsPosted: RecruitJobDetail[] = [];
  pagination: Pagination = {
    currentPage: 1,
    itemsPerPage: 10,
    totalItems: 100,
    totalPages: 10,
  };

  constructor(private recruitService: RecruitService) {}

  ngOnInit() {
    this.fetchJobsPosted();
  }
  fetchJobsPosted() {
    this.recruitService
      .fetchJobsPosted(
        this.pagination.currentPage,
        this.pagination.itemsPerPage
      )
      .subscribe((data) => {
        this.jobsPosted = data.result;
        this.pagination = data.pagination;
      });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.fetchJobsPosted();
  }
}
