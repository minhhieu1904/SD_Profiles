import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Feature } from '@models/feature';
import { PaginationResult, PaginationParam } from '@utilities/pagination-utility';

@Injectable({
  providedIn: 'root'
})
export class FeatureService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(feature: Feature) {
    return this.http.post<boolean>(`${this.baseUrl}Feature/Create`, feature);
  }

  update(feature: Feature) {
    return this.http.put<boolean>(`${this.baseUrl}Feature/Update`, feature);
  }

  delete(feature: Feature) {
    return this.http.put<boolean>(`${this.baseUrl}Feature/Delete`, feature);
  }

  getDataPagination(pagination: PaginationParam, text: string) {
    return this.http.get<PaginationResult<Feature>>(`${this.baseUrl}Feature/GetDataPagination`, { params: { ...pagination, text } });
  }
}
