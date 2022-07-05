import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Faq } from '@models/faq';
import { PaginationResult, PaginationParam } from '@utilities/pagination-utility';

@Injectable({
  providedIn: 'root'
})
export class FaqService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(faq: Faq) {
    return this.http.post<boolean>(`${this.baseUrl}Faq/Create`, faq);
  }

  update(faq: Faq) {
    return this.http.put<boolean>(`${this.baseUrl}Faq/Update`, faq);
  }

  delete(faq: Faq) {
    return this.http.put<boolean>(`${this.baseUrl}Faq/Delete`, faq);
  }

  getDataPagination(pagination: PaginationParam, text: string) {
    return this.http.get<PaginationResult<Faq>>(`${this.baseUrl}Faq/GetDataPagination`, { params: { ...pagination, text } });
  }
}
