import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { About } from '@models/about';
import { PaginationResult, PaginationParam } from '@utilities/pagination-utility';

@Injectable({
  providedIn: 'root'
})
export class AboutService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(about: About) {
    return this.http.post<boolean>(`${this.baseUrl}About/Create`, about);
  }

  update(about: About) {
    return this.http.put<boolean>(`${this.baseUrl}About/Update`, about);
  }

  delete(about: About) {
    return this.http.put<boolean>(`${this.baseUrl}About/Delete`, about);
  }

  getDataPagination(pagination: PaginationParam, text: string) {
    return this.http.get<PaginationResult<About>>(`${this.baseUrl}About/GetDataPagination`, { params: { ...pagination, text } });
  }
}
