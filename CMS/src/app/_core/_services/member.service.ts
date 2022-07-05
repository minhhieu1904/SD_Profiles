import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Member } from '@models/member';
import { PaginationResult, PaginationParam } from '@utilities/pagination-utility';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(member: Member) {
    return this.http.post<boolean>(`${this.baseUrl}Member/Create`, member);
  }

  update(member: Member) {
    return this.http.put<boolean>(`${this.baseUrl}Member/Update`, member);
  }

  delete(member: Member) {
    return this.http.put<boolean>(`${this.baseUrl}Member/Delete`, member);
  }

  getDataPagination(pagination: PaginationParam, text: string) {
    return this.http.get<PaginationResult<Member>>(`${this.baseUrl}Member/GetDataPagination`, { params: { ...pagination, text } });
  }
}
