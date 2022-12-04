import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { MessageService } from 'primeng/api';
import { Book } from 'src/app/models/book';
import { KeyValue } from 'src/app/models/keyvalue';
import { BookService } from 'src/app/services/book.service';
import { RelatedDataService } from 'src/app/services/related.data.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent implements OnInit {
  public books!: Book[];
  public statuses!: KeyValue[];
  public selectedBook!: Book;
  dialogVisible: boolean = false;
  displayNotes: boolean = false;
  selectedBookNotesRows: string[] = [];

  constructor(
    private bookService: BookService,
    private messageService: MessageService,
    private relatedDataService: RelatedDataService
  ) {}

  ngOnInit(): void {
    this.onTableUpdate();
    this.relatedDataService.getStatuses().subscribe((s) => {
      this.statuses = s;
    });
  }

  onTableUpdate() {
    this.bookService.getBooks().subscribe((b) => {
      this.books = b;
    });
  }

  onDialogClose() {
    this.dialogVisible = false;
  }

  showNotes(notes: string) {
    this.selectedBookNotesRows = notes.split('\n');
    this.displayNotes = true;
  }

  openNew() {
    this.selectedBook = {};
    this.dialogVisible = true;
  }

  editBook(book: Book) {
    this.selectedBook = { ...book };
    this.dialogVisible = true;
  }

  deleteBook(id: Guid) {
    this.bookService.deleteBook(id).subscribe({
      next: (p) => {
        this.onTableUpdate();
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Book deleted',
          life: 3000,
        });
      },
    });
  }

  getStatusSeverity(status: string) {
    if (status === 'Unknown') {
      return 'danger';
    } else if (status === 'Planning to read') {
      return 'warning';
    } else if (status === 'Currently reading') {
      return 'info';
    } else {
      return 'success';
    }
  }
}
