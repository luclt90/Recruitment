import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Career } from '../_models/career';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  baseUrl = environment.apiUrl + 'home/';
  constructor(private http: HttpClient) {}

  getAllCareers(): Observable<Career[]> {
    return this.http.get<Career[]>(this.baseUrl + 'careers');
  }

  countCandidates(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'candidate/count');
  }

  countRecruits(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'recruit/count');
  }

  countRecruitJobs(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'recruit-job/count');
  }
}
