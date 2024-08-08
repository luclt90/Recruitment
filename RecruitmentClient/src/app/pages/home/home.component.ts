import { Component, OnInit } from '@angular/core';
import { Profession } from 'src/app/_models/profession';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProfessionService } from 'src/app/_services/profession.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonService } from 'src/app/_services/common.service';
import { City } from 'src/app/_models/city';
import { HomeService } from 'src/app/_services/home.service';
import { Career } from 'src/app/_models/career';
import { RecruitJobService } from 'src/app/_services/recruit-job.service';
import { RecruitJobInfo } from 'src/app/_models/recruit-job-info';
import { EnumTypeJob } from 'src/app/_models/enum';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  professions: Profession[] = [];
  selectedProfession: number = 1;
  professionLoading = false;

  cities: City[] = [];
  selectedCity: number = 1;
  cityLoading = false;

  careers: Career[] = [];

  recruitJobInfos: RecruitJobInfo[] = [];

  candidateNumber: number = 0;
  recruitNumber: number = 0;
  recruitJobNumber: number = 0;

  startTime!: number;
  initTime!: number;
  contentInitTime!: number;
  viewInitTime!: number;
  printTime(time: number) {
    console.log(`Global loading ${time}ms`);
    console.log(`Global loading ${time / 1000}s`);
    console.log(`Component loading ${time - this.startTime}ms`);
    console.log(`Component loading ${(time - this.startTime) / 1000}s`);
  }

  constructor(
    private professionService: ProfessionService,
    private commonService: CommonService,
    private homeService: HomeService,
    private recruitJobService: RecruitJobService,
    private alertify: AlertifyService
  ) {
    this.startTime = window.performance.now();
    this.printTime(this.startTime);
  }

  ngOnInit() {
    this.loadProfessions();
    this.loadCities();
    this.loadCareers();
    this.loadHotJobs();

    this.countRecruit();
    this.countCandidate();
    this.countRecruitJob();

    this.initTime = window.performance.now();
    this.printTime(this.initTime);
  }

  // // Rendered without children
  // ngAfterContentInit() {
  //   this.contentInitTime = window.performance.now();
  //   this.printTime(this.contentInitTime);
  // }
  // // Rendered with children
  // ngAfterViewInit() {
  //   this.viewInitTime = window.performance.now();
  //   this.printTime(this.viewInitTime);
  // }

  loadProfessions() {
    this.professionLoading = true;
    this.professionService.getAllProfessions().subscribe(
      (data) => {
        this.professions = data;
        this.professionLoading = false;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadCities() {
    this.cityLoading = true;
    this.commonService.getCities().subscribe(
      (data) => {
        this.cities = data;
        this.cityLoading = false;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadCareers() {
    this.homeService.getAllCareers().subscribe(
      (data) => {
        this.careers = data;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  loadHotJobs() {
    this.recruitJobService.getListRecruitJobsByType(EnumTypeJob.Hot).subscribe(
      (data) => {
        this.recruitJobInfos = data;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  countCandidate() {
    this.homeService.countCandidates().subscribe(
      (data) => {
        this.candidateNumber = data;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  countRecruit() {
    this.homeService.countRecruits().subscribe(
      (data) => {
        this.recruitNumber = data;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  countRecruitJob() {
    this.homeService.countRecruitJobs().subscribe(
      (data) => {
        this.recruitJobNumber = data;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
}
