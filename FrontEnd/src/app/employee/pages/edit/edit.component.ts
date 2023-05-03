import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IEmployee } from '../../interface/IEmployee';
import { EmployeeService } from '../../services/employee.service';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  employee: IEmployee = { id: 0, name: '', lastName: '', createdDate: '' };


  constructor(private activatedRoute: ActivatedRoute, private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.activatedRoute.params
      .pipe(switchMap((param) => this.employeeService.GetEmployee(param["id"])))
      .subscribe(resp => {
        this.employee = resp;
      });
  }

}
