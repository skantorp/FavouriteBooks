import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Book } from 'src/app/models/book';
import { KeyValue } from 'src/app/models/keyvalue';
import { BookService } from 'src/app/services/book.service';
import { RelatedDataService } from 'src/app/services/related.data.service';

@Component({
  selector: 'app-book-update-modal',
  templateUrl: './book-update-modal.component.html',
  styleUrls: ['./book-update-modal.component.css']
})
export class BookUpdateModalComponent implements OnInit {

  @Input() public book!: Book;
  @Input() visible: boolean = false;
  @Output() onClose = new EventEmitter();
  @Output() onTableUpdate = new EventEmitter();
  public authors!: KeyValue[];
  public genres!: KeyValue[];
  public statuses!: KeyValue[];
  submitted!: boolean;

  constructor(private bookService: BookService,
    private relatedDataService: RelatedDataService) { }

  ngOnInit(): void {
    this.relatedDataService.getAuthors().subscribe(a => {
      this.authors = a;
    });
    this.relatedDataService.getGenres().subscribe(g => {
      this.genres = g;
    });
    this.relatedDataService.getStatuses().subscribe(s => {
      this.statuses = s;
    });
    
    this.submitted = false;
  }

  hideDialog() {
    console.log(this.book);
    this.onClose.emit();
  }

  submitBookUpdating() {
    let isBookExists = !!this.book.id;
    if(isBookExists) {
      this.bookService.updateBook(this.book).subscribe({
        next: p => {
          this.hideDialog();
          this.onTableUpdate.emit();
        }
      });
    }
    else {
      this.bookService.createBook(this.book).subscribe({
        next: p => {
          this.hideDialog();
          this.onTableUpdate.emit();
        }
      });
    }
  }

}
