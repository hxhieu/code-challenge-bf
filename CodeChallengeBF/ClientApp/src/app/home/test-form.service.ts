import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { environment } from 'src/environments/environment';

export interface TestForm {
  firstName?: string;
  lastName?: string;
}

@Injectable({
  providedIn: 'root',
})
export class TestFormService {
  private readonly _baseUrl: string;
  constructor(private http: HttpClient, private toast: ToastrService) {
    this._baseUrl = environment.apiBaseUrl;
  }

  private handleError<T>() {
    return (err: any): Observable<T> => {
      const { error, message } = err;
      // This error comes from server side global exception handler
      const actualErr = JSON.stringify(error.errors || error.error) || message;
      this.toast.error(actualErr, `Error`);
      // Let the app keep running by returning an empty result.
      return of(undefined as T);
    };
  }

  public sendTestForm(form: TestForm) {
    this.http
      .post<TestForm>(this._baseUrl + '/testform', form)
      .pipe(catchError(this.handleError()))
      .subscribe((x) => {
        if (x) {
          this.toast.success('The form has been submitted', 'Success');
        }
      });
  }
}
