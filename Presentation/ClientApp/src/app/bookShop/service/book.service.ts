import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Book } from '../models/book';
import { HandleHttpErrorService } from './handleHttpError.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class BookService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleHttpErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseUrl + 'api/Book')
      .pipe(
        tap(_ => this.handleHttpErrorService.log('Date Consult')),
        catchError(this.handleHttpErrorService.handleError<Book[]>('Consult Book', null))
      );
  }

  post(book: Book): Observable<Book> {
    return this.http.post<Book>(this.baseUrl + 'api/Book', book)
      .pipe(
        tap(() => this.handleHttpErrorService.log('Date Save')),
        catchError(this.handleHttpErrorService.handleError<Book>('Register Book', null))
      );
  }

  put(book: Book): Observable<any> {
    const url = `${this.baseUrl}api/Book/${book.reference}`;
    return this.http.put(url, book, httpOptions)
    .pipe(
      tap(_ => this.handleHttpErrorService.log('Date Update')),
      catchError(this.handleHttpErrorService.handleError<any>('Update Book'))
    );
  }

  delete(reference: string): Observable<Book> {
    const url = `${this.baseUrl + 'api/Book'}/${reference}`;
    return this.http.delete<Book>(url, httpOptions)
      .pipe(
        tap(_ => this.handleHttpErrorService.log('Date Delete')),
        catchError(this.handleHttpErrorService.handleError<Book>('Delete Book', null))
      );
  }

  getReference(reference: string): Observable<Book> {
    const url = `${this.baseUrl + 'api/Book'}/${reference}`;
    return this.http.get<Book>(url, httpOptions)
      .pipe(
        tap(_ => this.handleHttpErrorService.log('Date Find')),
        catchError(this.handleHttpErrorService.handleError<Book>('Find Book', null))
      );
  }

}