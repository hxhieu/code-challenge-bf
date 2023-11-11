import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of } from 'rxjs';
import { environment } from 'src/environments/environment';

export interface TestForm {
  firstName?: string | null;
  lastName?: string | null;
}

@Injectable({
  providedIn: 'root',
})
export class TestFormService {
  private readonly _baseUrl: string;
  constructor(private http: HttpClient) {
    this._baseUrl = environment.apiBaseUrl;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  public sendTestForm(form: TestForm) {
    this.http
      .post<TestForm>(this._baseUrl + '/testform', form)
      .pipe(catchError(this.handleError('sendTestForm', [])))
      .subscribe();
  }
}
