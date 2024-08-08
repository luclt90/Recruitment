import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RecruitJobEdit } from '../_models/recruit-job-edit';
import { RecruitJobInfo } from '../_models/recruit-job-info';

@Injectable({
  providedIn: 'root',
})
export class RecruitJobService {
  baseUrl = environment.apiUrl + 'recruitjob/';
  constructor(private http: HttpClient) {}

  getListRecruitJobsByType(type?: number): Observable<RecruitJobInfo[]> {
    return this.http.get<RecruitJobInfo[]>(this.baseUrl + 'all/' + type);
  }

  postANewJob(recruitJobEdit: RecruitJobEdit) {
    return this.http.post<any>(this.baseUrl + 'add/', recruitJobEdit);
  }

}
