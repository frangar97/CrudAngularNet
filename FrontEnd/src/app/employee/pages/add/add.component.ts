import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from '../../services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent {

  createEmployeeForm: FormGroup = this.formBuilder.group({
    name: ['', [Validators.required]],
    lastName: ['', [Validators.required]]
  });

  constructor(private formBuilder: FormBuilder, private employeeService: EmployeeService, private router: Router) { }

  submit() {

    if (this.createEmployeeForm.invalid) {
      this.createEmployeeForm.markAllAsTouched();
      return;
    }

    this.employeeService.CreateEmployee(this.createEmployeeForm.value)
      .subscribe(resp => {
        this.router.navigate(['']);
      });
  }
}
