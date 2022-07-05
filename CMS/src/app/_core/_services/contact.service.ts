import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '@env/environment';
import { Contact } from '@models/contact';
import { PaginationResult, PaginationParam } from '@utilities/pagination-utility';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  baseUrl = environment.apiUrl;
  constructor(
    private http: HttpClient
  ) { }

  create(contact: Contact) {
    return this.http.post<boolean>(`${this.baseUrl}Contact/Create`, contact);
  }

  update(contact: Contact) {
    return this.http.put<boolean>(`${this.baseUrl}Contact/Update`, contact);
  }

  delete(contact: Contact) {
    return this.http.put<boolean>(`${this.baseUrl}Contact/Delete`, contact);
  }

  getDataPagination(pagination: PaginationParam, text: string) {
    return this.http.get<PaginationResult<Contact>>(`${this.baseUrl}Contact/GetDataPagination`, { params: { ...pagination, text } });
  }
}
