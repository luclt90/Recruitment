import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { Component, OnInit } from '@angular/core';
import { City } from 'src/app/_models/city';
import { District } from 'src/app/_models/district';
import { Experience } from 'src/app/_models/experience';
import { LevelInfo } from 'src/app/_models/level-info';
import { RecruitJobEdit } from 'src/app/_models/recruit-job-edit';
import { Salary } from 'src/app/_models/salary';
import { Ward } from 'src/app/_models/ward';
import { WorkType } from 'src/app/_models/work-type';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { CommonService } from 'src/app/_services/common.service';
import { RecruitJobService } from 'src/app/_services/recruit-job.service';

import { Genders } from 'src/app/_models/gender';

@Component({
  selector: 'app-post-job',
  templateUrl: './post-job.component.html',
  styleUrls: ['./post-job.component.css'],
})
export class PostJobComponent implements OnInit {
  cities: City[] = [];
  cityLoading = false;

  districts: District[] = [];
  districtLoading = false;

  wards: Ward[] = [];
  wardLoading = false;

  workTypes: WorkType[] = [];
  workTypeLoading = false;

  experiences: Experience[] = [];
  experienceLoading = false;

  levelInfos: LevelInfo[] = [];
  levelInfoLoading = false;

  salaries: Salary[] = [];
  salaryLoading = false;

  public Editor = ClassicEditor;

  public genders = Genders;

  recruitJobEdit: RecruitJobEdit = new RecruitJobEdit();

  constructor(
    private authService: AuthService,
    private commonService: CommonService,
    private recruitJobService: RecruitJobService,
    private alertify: AlertifyService
  ) {}

  ngOnInit() {
    this.loadSalaries();
    this.loadLevelInfos();
    this.loadExperiences();
    this.loadWorkTypes();
    this.loadCities();
  }

  postANewJob() {
    this.recruitJobEdit.recruitId = this.authService.currentUser.id;
    this.recruitJobService.postANewJob(this.recruitJobEdit).subscribe(
      (response) => {
        this.alertify.success(response.message);
      },
      (error) => {
        this.alertify.error(error.message);
      }
    );
  }

  loadWorkTypes() {
    this.workTypeLoading = true;
    this.commonService.getWorkTypes().subscribe(
      (data) => {
        this.workTypes = data;
        this.workTypeLoading = false;
      },
      (error) => {
        this.alertify.error(error);
        this.workTypeLoading = false;
      }
    );
  }

  loadExperiences() {
    this.experienceLoading = true;
    this.commonService.getExperiences().subscribe(
      (data) => {
        this.experiences = data;
        this.experienceLoading = false;
      },
      (error) => {
        this.alertify.error(error);
        this.experienceLoading = false;
      }
    );
  }

  loadLevelInfos() {
    this.levelInfoLoading = true;
    this.commonService.getLevelInfos().subscribe(
      (data) => {
        this.levelInfos = data;
        this.levelInfoLoading = false;
      },
      (error) => {
        this.alertify.error(error);
        this.levelInfoLoading = false;
      }
    );
  }

  loadSalaries() {
    this.salaryLoading = true;
    this.commonService.getSalaries().subscribe(
      (data) => {
        this.salaries = data;
        this.salaryLoading = false;
      },
      (error) => {
        this.alertify.error(error);
        this.salaryLoading = false;
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
        this.cityLoading = false;
      }
    );
  }

  selectedCityChanged(cityId: number) {
    this.districtLoading = true;
    if (cityId) {
      this.commonService.getDistrictsByCityId(cityId).subscribe(
        (data) => {
          this.districts = data;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
    }

    this.districtLoading = false;
  }

  selectedDistrictChanged(districtId: number) {
    this.wardLoading = true;
    if (districtId) {
      this.commonService.getWardsByDistrictId(districtId).subscribe(
        (data) => {
          this.wards = data;
        },
        (error) => {
          this.alertify.error(error);
        }
      );
    }

    this.wardLoading = false;
  }
}
