import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { HttpClient } from '@angular/common/http';
import { Position } from '@models/position';
import { PaginationResult, PaginationParam } from '@utilities/pagination-utility';
import { KeyValuePair } from '@utilities/key-value-pair';

@Injectable({
  providedIn: 'root'
})
export class PositionService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(positon: Position) {
    return this.http.post<boolean>(`${this.baseUrl}Position/Create`, positon);
  }

  update(positon: Position) {
    return this.http.put<boolean>(`${this.baseUrl}Position/Update`, positon);
  }

  delete(positon: Position) {
    return this.http.put<boolean>(`${this.baseUrl}Position/Delete`, positon);
  }

  getData(pagination: PaginationParam, text: string) {
    return this.http.get<PaginationResult<Position>>(`${this.baseUrl}Position/GetDataPagination`, { params: { ...pagination, text } });
  }

  getListPosition() {
    return this.http.get<KeyValuePair[]>(`${this.baseUrl}Position/GetListPosition`);
  }
}
