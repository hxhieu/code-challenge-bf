import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { TestFormService } from './test-form.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  constructor(
    private readonly testFormService: TestFormService, //
    private readonly formBuilder: FormBuilder
  ) {}

  testForm = this.formBuilder.nonNullable.group({
    firstName: ['', [Validators.required]],
    lastName: ['', [Validators.required]],
  });

  onSubmit(): void {
    if (!this.testForm.valid) {
      return;
    }
    this.testFormService.sendTestForm(this.testForm.value);
  }
}
