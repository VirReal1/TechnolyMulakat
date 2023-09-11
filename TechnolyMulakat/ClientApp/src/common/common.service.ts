import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CodeListModel } from './common.model';

@Injectable()
export class CommonService {

  constructor(private http: HttpClient) { }

  getCities(): Observable<CodeListModel[]> {
    return this.http.get<CodeListModel[]>('api/common/cities');
  }

  getAirports(): Observable<CodeListModel[]> {
    return this.http.get<CodeListModel[]>('api/common/airports');
  }
}
