import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  NgForm,
  NumberValueAccessor,
} from '@angular/forms';
import { City } from 'src/app/_models/city';
import { CompanySize } from 'src/app/_models/company-size';
import { District } from 'src/app/_models/district';
import { Profession } from 'src/app/_models/profession';
import { Recruit } from 'src/app/_models/recruit';
import { Ward } from 'src/app/_models/ward';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { CommonService } from 'src/app/_services/common.service';
import { ProfessionService } from 'src/app/_services/profession.service';
import { RecruitService } from 'src/app/_services/recruit.service';

@Component({
  selector: 'app-recruit-profile',
  templateUrl: './recruit-profile.component.html',
  styleUrls: ['./recruit-profile.component.css'],
})
export class RecruitProfileComponent implements OnInit {
  professions: Profession[] = [];
  professionLoading = false;

  companySizes: CompanySize[] = [];
  companySizeLoading = false;

  cities: City[] = [];
  cityLoading = false;

  districts: District[] = [];
  districtLoading = false;

  wards: Ward[] = [];
  wardLoading = false;

  modelUpdateInfo: any = {};
  recruit: Recruit;

  updateInfoForm: FormGroup;

  constructor(
    private authService: AuthService,
    private recruitService: RecruitService,
    private professionService: ProfessionService,
    private commonService: CommonService,
    private alertify: AlertifyService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.loadCompanySizes();
    this.loadProfessions();
    this.loadCities();
    this.loadRecruitDetail();
  }

  selectedCityChanged(cityId: number, refresh: boolean = true) {
    this.districtLoading = true;
    if (refresh) {
      this.recruit.districtId = null;
    }
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

  selectedDistrictChanged(districtId: number, refresh: boolean = true) {
    this.wardLoading = true;
    if (refresh) {
      this.recruit.wardId = null;
    }
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

  loadCompanySizes(){
    this.companySizeLoading = true;
    this.commonService.getCompanySizes().subscribe(
      (data) => {
        this.companySizes = data;
        this.companySizeLoading = false;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

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

  loadRecruitDetail() {
    this.recruitService
      .getDetailRecruitById(this.authService.currentUser.id)
      .subscribe(
        (data) => {
          this.recruit = data;
          if (data.cityId) {
            this.selectedCityChanged(data.cityId, false);
          }
          if (data.districtId) {
            this.selectedDistrictChanged(data.districtId, false);
          }
        },
        (error) => {
          this.alertify.error(error);
        }
      );
  }

  updateInfo() {
    this.recruitService.updateRecruitInfo(this.recruit).subscribe(
      (response) => {
        this.alertify.success(response.message);
      },
      (error) => {
        this.alertify.error(error.message);
      }
    );
  }

  updateContact() {
    this.recruitService.updateRecruitContact(this.recruit).subscribe(
      (response) => {
        this.alertify.success(response.message);
      },
      (error) => {
        this.alertify.error(error.message);
      }
    );
  }

  // createUpdateInfoForm() {
  //   this.updateInfoForm = this.fb.group(
  //     {
  //       type: ['', Validators.required],
  //       userName: ['', Validators.required],
  //       email: ['', Validators.required],
  //       phone: [null, Validators.required],
  //       password: [
  //         '',
  //         [
  //           Validators.required,
  //           Validators.minLength(4),
  //           Validators.maxLength(8),
  //         ],
  //       ],
  //       confirmPassword: ['', Validators.required],
  //     },
  //     { validator: this.passwordMatchValidator }
  //   );
  // }
}
