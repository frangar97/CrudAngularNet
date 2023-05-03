import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { switchMap } from 'rxjs/operators';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  constructor(private activatedRoute: ActivatedRoute, private employeeService: EmployeeService, private router: Router, private formBuilder: FormBuilder) { }

  employeeId: number = 0;

  editEmployeeForm: FormGroup = this.formBuilder.group({
    name: ['', [Validators.required]],
    lastName: ['', [Validators.required]]
  });

  ngOnInit(): void {
    this.activatedRoute.params
      .pipe(switchMap((param) => this.employeeService.GetEmployee(param["id"])))
      .subscribe(resp => {
        this.employeeId = resp.id;
        this.editEmployeeForm.setValue({ name: resp.name, lastName: resp.lastName });
      });
  }

  submit() {

    if (this.editEmployeeForm.invalid) {
      this.editEmployeeForm.markAllAsTouched();
      return;
    }

    this.employeeService.UpdateteEmployee(this.employeeId, this.editEmployeeForm.value)
      .subscribe(resp => {
        this.router.navigate(['']);
      });
  }

}
