import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployees() {
    const url = environment.urlServices.employeePayRoll;
    return this.http.get(url);
  }

  getEmployee(id: number) {
    const url = `${environment.urlServices.employeePayRoll}/${id}`;
    return this.http.get(url);
  }
}
