import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from '../models/book';
import { UpdateBookModel } from '../models/request.models';

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
    let request = this.convertToRequest(book);

    return this.http.post<Book>(url, request);
  }

  updateBook(book: Book) {
    let url = this.bookUrl;
    let request = this.convertToRequest(book);

    return this.http.put<Book>(url, request);
  }

  deleteBook(id: Guid) {
    let url = this.bookUrl + `?id=${id.toString()}`;

    return this.http.delete(url);
  }

  private convertToRequest(book: Book): UpdateBookModel {
    let request: UpdateBookModel = {
      id: book.id,
      name: book.name as string,
      genreId: book.genre?.id as Guid,
      statusId: book.status?.id as Guid,
      notes: book.notes,
    };
    if (!!book.author?.id) {
      request.authorId = book.author?.id;
    } else {
      request.authorName = book.author as string;
    }

    return request;
  }
}
