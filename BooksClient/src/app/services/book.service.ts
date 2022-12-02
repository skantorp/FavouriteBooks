import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from '../models/book';

@Injectable()
export class BookService {
  bookUrl = environment.apiUrl + '/books';

  constructor(private http: HttpClient) {}

  getBooks(): Observable<Book[]> {
    const url = this.bookUrl;
    return this.http.get<Book[]>(url);
  }

  createBook(book: Book) {
    let url = this.bookUrl;

    return this.http.post<Book>(url, {
      ...book,
      authorId: book.author?.id,
      genreId: book.genre?.id,
      statusId: book.status?.id,
    });
  }

  updateBook(book: Book) {
    let url = this.bookUrl;

    return this.http.put<Book>(url, {
      ...book,
      authorId: book.author?.id,
      genreId: book.genre?.id,
      statusId: book.status?.id,
    });
  }

  deleteBook(id: Guid) {
    let url = this.bookUrl + `?id=${id.toString()}`;

    return this.http.delete(url);
  }
}
