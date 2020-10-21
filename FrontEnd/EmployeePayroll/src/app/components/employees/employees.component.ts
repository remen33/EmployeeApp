import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
})
export class EmployeesComponent implements OnInit {
  thereAreNoItems = false;
  thereAreError = false;
  public form: FormGroup;
  employees: Employee[] = [];
  constructor(
    private formBuilder: FormBuilder,
    private employeeService: EmployeeService
  ) {
    this.form = this.formBuilder.group({
      employeeId: [],
    });
  }

  ngOnInit(): void {}

  getEmployees() {
    this.thereAreNoItems = false;
    this.thereAreError = false;
    if (this.form.value.employeeId) {
      this.employeeService
        .getEmployee(this.form.value.employeeId)
        .pipe(take(1))
        .subscribe((response: Employee) => {
          this.employees = [];
          if (response) {
            this.employees.push(response);
          } else {
            this.thereAreNoItems = true;
          }
        },
        error => {
          this.thereAreError = true;
          console.log('error');
        });

      return;
    }

    this.employeeService.getEmployees()
    .pipe(take(1))
    .subscribe((response: Employee[]) => {
      this.employees = response;
    });
  }
}
