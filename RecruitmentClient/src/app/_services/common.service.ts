import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { City } from '../_models/city';
import { CompanySize } from '../_models/company-size';
import { District } from '../_models/district';
import { Experience } from '../_models/experience';
import { LevelInfo } from '../_models/level-info';
import { Salary } from '../_models/salary';
import { Ward } from '../_models/ward';
import { WorkType } from '../_models/work-type';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  baseUrl = environment.apiUrl + 'common/';
  constructor(private http: HttpClient) {}

  getCompanySizes(): Observable<CompanySize[]> {
    return this.http.get<CompanySize[]>(this.baseUrl + 'company-sizes');
  }

  getCities(): Observable<City[]> {
    return this.http.get<City[]>(this.baseUrl + 'cities');
  }

  getDistrictsByCityId(cityId: number): Observable<District[]> {
    return this.http.get<District[]>(this.baseUrl + 'districts/' + cityId);
  }

  getWardsByDistrictId(districtId: number): Observable<Ward[]> {
    return this.http.get<Ward[]>(this.baseUrl + 'wards/' + districtId);
  }

  getExperiences(): Observable<Experience[]> {
    return this.http.get<Experience[]>(this.baseUrl + 'experiences');
  }

  getLevelInfos(): Observable<LevelInfo[]> {
    return this.http.get<LevelInfo[]>(this.baseUrl + 'level-info');
  }

  getSalaries(): Observable<Salary[]> {
    return this.http.get<Salary[]>(this.baseUrl + 'salaries');
  }

  getWorkTypes(): Observable<WorkType[]> {
    return this.http.get<WorkType[]>(this.baseUrl + 'work-type');
  }
}
