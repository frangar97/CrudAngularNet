import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEmployee } from '../interface/IEmployee';
import { ICreateEmployee } from '../interface/ICreateEmployee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  APIURL = "http://localhost:5092";

  constructor(private http: HttpClient) { }

  GetAllEmployees(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(`${this.APIURL}/api/employee`);
  }

  GetEmployee(id: number): Observable<IEmployee> {
    return this.http.get<IEmployee>(`${this.APIURL}/api/employee/${id}`);
  }

  CreateEmployee(employee: ICreateEmployee): Observable<IEmployee> {
    return this.http.post<IEmployee>(`${this.APIURL}/api/employee`, employee);
  }

  UpdateteEmployee(id: number, employee: ICreateEmployee): Observable<any> {
    return this.http.put(`${this.APIURL}/api/employee/${id}`, employee);
  }

  DeleteEmployee(id: number): Observable<any> {
    return this.http.delete(`${this.APIURL}/api/employee/${id}`);
  }
}
