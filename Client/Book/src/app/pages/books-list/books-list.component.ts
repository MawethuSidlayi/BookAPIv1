import { Component, Input, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookSubscriptions } from 'src/app/models/bookSubscriptions';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.sass']
})
export class BooksListComponent implements OnInit {
  list: Book[]
  @Input() books: Book[] = [];
  book ={} as BookSubscriptions;

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    if(this.books.length == 0){
      this.bookService.getAllBooks().subscribe(books => this.list = books); 
    }
    else{
      this.list = this.books;
    }


  }   
   subscribeToBook(id: number): void {

    console.log(id);

      this.book.book_Id = id
      this.bookService.subscribeToBook(id);
  }
}
