import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Book } from 'src/app/models/book';
import { KeyValue } from 'src/app/models/keyvalue';
import { BookService } from 'src/app/services/book.service';
import { RelatedDataService } from 'src/app/services/related.data.service';

@Component({
  selector: 'app-book-update-modal',
  templateUrl: './book-update-modal.component.html',
  styleUrls: ['./book-update-modal.component.css'],
})
export class BookUpdateModalComponent implements OnInit {
  @Input() public book!: Book;
  @Input() visible: boolean = false;
  @Output() dialogClose = new EventEmitter();
  @Output() tableUpdate = new EventEmitter();
  public authors: KeyValue[] = [{}];
  public genres!: KeyValue[];
  public statuses!: KeyValue[];
  submitted!: boolean;

  constructor(
    private bookService: BookService,
    private relatedDataService: RelatedDataService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.relatedDataService.getAuthors().subscribe((a) => {
      this.authors.concat(a);
    });
    this.relatedDataService.getGenres().subscribe((g) => {
      this.genres = g;
    });
    this.relatedDataService.getStatuses().subscribe((s) => {
      this.statuses = s;
    });

    this.submitted = false;
  }

  hideDialog() {
    this.dialogClose.emit();
    this.submitted = false;
  }

  submitBookUpdating() {
    this.submitted = true;

    if (!this.validate()) {
      return;
    }

    let bookExists = !!this.book.id;
    if (bookExists) {
      this.bookService.updateBook(this.book).subscribe({
        next: (p) => this.afterBookUpdating(bookExists),
      });
    } else {
      this.bookService.createBook(this.book).subscribe({
        next: (p) => this.afterBookUpdating(bookExists),
      });
    }
  }

  afterBookUpdating(bookExists: boolean) {
    let messageLabel = bookExists ? 'Book updated' : 'Book created';

    this.hideDialog();
    this.messageService.add({
      severity: 'success',
      summary: 'Successful',
      detail: messageLabel,
      life: 3000,
    });
    this.tableUpdate.emit();
  }

  validate(): boolean {
    return (
      this.submitted &&
      !!this.book.name &&
      !!this.book.author &&
      !!this.book.genre &&
      !!this.book.status
    );
  }
}
