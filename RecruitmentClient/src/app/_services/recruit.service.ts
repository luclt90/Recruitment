import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_models/pagination';
import { Recruit } from '../_models/recruit';
import { RecruitJobDetail } from '../_models/recruit-job-detail';
import { AuthService } from './auth.service';
import { EndpointBaseService } from './endpoint-base.service';

@Injectable({
  providedIn: 'root',
})
export class RecruitService extends EndpointBaseService {
  baseUrl = environment.apiUrl + 'recruit/';
  constructor(private http: HttpClient, private authService: AuthService) {
    super();
  }

  getDetailRecruitById(id: number): Observable<Recruit> {
    return this.http.get<Recruit>(this.baseUrl + 'recruit-info/' + id, {
      headers: this.requestHeaders,
    });
  }

  updateRecruitContact(recruit: Recruit) {
    return this.http.put<any>(this.baseUrl + 'update/contact', recruit, {
      headers: this.requestHeaders,
    });
  }

  updateRecruitInfo(recruit: Recruit) {
    return this.http.put<any>(this.baseUrl + 'update/info', recruit, {
      headers: this.requestHeaders,
    });
  }

  fetchJobsPosted(
    page?: any,
    itemsPerPage?: any
  ): Observable<PaginatedResult<RecruitJobDetail[]>> {
    const paginatedResult: PaginatedResult<RecruitJobDetail[]> =
      new PaginatedResult<RecruitJobDetail[]>();

    let params = new HttpParams();
    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http
      .get<RecruitJobDetail[]>(this.baseUrl + 'jobs-posted', {
        headers: this.requestHeaders,
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(
              response.headers.get('Pagination')
            );
          }
          return paginatedResult;
        })
      );
  }
}
