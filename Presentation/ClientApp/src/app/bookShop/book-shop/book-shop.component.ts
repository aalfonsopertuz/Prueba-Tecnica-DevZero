import { Component, OnInit } from '@angular/core';
import { JsonFormatter } from 'tslint/lib/formatters';
import { Book } from '../models/book';
import { BookService } from '../service/book.service';

@Component({
  selector: 'app-book-shop',
  templateUrl: './book-shop.component.html',
  styleUrls: ['./book-shop.component.css']
})
export class BookShopComponent implements OnInit {

  newBook: Book;
  newBookEdit: Book;
  books: Book[];


  constructor( private service: BookService ) { }

  ngOnInit() {
    this.newBook = new Book();
    this.newBookEdit = new Book();
    this.get(); 
  }

  add(){
    this.service.post(this.newBook).subscribe(result => {
      result = this.newBook;
      this.get();
    });
  }

  get() {
    this.service.get().subscribe(result => {
      this.books = result;
      // alert(JSON.stringify(result));
    });
  }

  update() {
    this.service.put(this.newBookEdit).subscribe(result => {
      result = this.newBookEdit;
      this.get();
    });
    
  }

  remove(reference: string) {
    this.service.delete(reference).subscribe(result => {
     this.get();
    });
    
  }

  getReference(reference: string){
    this.service.getReference(reference).subscribe(result => {
      this.newBookEdit = result;

    });
  }

 

}
