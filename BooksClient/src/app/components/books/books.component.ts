import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Book } from 'src/app/models/book';
import { KeyValue } from 'src/app/models/keyvalue';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  public books!: Book[];
  public selectedBook!: Book;
  dialogVisible: boolean = false;

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.onTableUpdate();
  }

  onTableUpdate() {
    this.bookService.getBooks().subscribe(b => {
      this.books = b;
    });
  }

  onDialogClose() {
    this.dialogVisible = false;
  }

  openNew() {
    this.selectedBook = {};
    this.dialogVisible = true;
  }

  editBook(book: Book) {
    this.selectedBook = {...book};
    this.dialogVisible = true;
  }

  deleteBook(id: Guid) {
    this.bookService.deleteBook(id).subscribe();
  }

}
