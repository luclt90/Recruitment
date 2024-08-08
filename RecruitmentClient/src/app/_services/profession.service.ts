import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Profession } from '../_models/profession';

@Injectable({
  providedIn: 'root',
})
export class ProfessionService {
  baseUrl = environment.apiUrl + 'profession/';
  constructor(private http: HttpClient) {}

  getAllProfessions(): Observable<Profession[]> {
    return this.http.get<Profession[]>(this.baseUrl + 'professions');
  }

}
