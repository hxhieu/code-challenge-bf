import { Component } from '@angular/core';
import {  FormBuilder } from '@angular/forms';
import { TestFormService } from './test-form.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(
    private readonly testFormService: TestFormService, //
    private readonly formBuilder: FormBuilder
  ) {}

  testForm = this.formBuilder.group({
    firstName: '',
    lastName: '',
  });

  onSubmit(): void {
    this.testFormService.sendTestForm(this.testForm.value);
  }
}
