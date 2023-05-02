import { Component, OnInit } from '@angular/core';
import { IEmployee } from '../../interface/IEmployee';
import { EmployeeService } from '../../services/employee.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  employees: IEmployee[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.GetAllEmployees();
  }

  GetAllEmployees() {
    this.employeeService.GetAllEmployees().subscribe(resp => {
      this.employees = resp;
    });
  }

  DeleteEmployee(id: number) {
    this.employeeService.DeleteEmployee(id).subscribe(resp => {
      this.GetAllEmployees();
    })
  }

}
