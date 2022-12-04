import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { SliderModule } from 'primeng/slider';
import { MultiSelectModule } from 'primeng/multiselect';
import { ContextMenuModule } from 'primeng/contextmenu';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { ToolbarModule } from 'primeng/toolbar';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BadgeModule } from 'primeng/badge';
import { MessageService } from 'primeng/api';
import { ConfirmationService } from 'primeng/api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BooksComponent } from './components/books/books.component';
import { BookUpdateModalComponent } from './components/book-update-modal/book-update-modal.component';
import { BookService } from './services/book.service';
import { RelatedDataService } from './services/related.data.service';

@NgModule({
  declarations: [AppComponent, BooksComponent, BookUpdateModalComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TableModule,
    ToastModule,
    SliderModule,
    MultiSelectModule,
    ContextMenuModule,
    DialogModule,
    ButtonModule,
    DropdownModule,
    InputTextModule,
    ToolbarModule,
    HttpClientModule,
    FormsModule,
    ConfirmDialogModule,
    BrowserAnimationsModule,
    BadgeModule,
  ],
  providers: [
    BookService,
    RelatedDataService,
    MessageService,
    ConfirmationService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
