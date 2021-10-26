import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from "rxjs/operators"; 
import { BookSubscriptions } from '../models/bookSubscriptions';
@Injectable({
  providedIn: 'root'
})
export class BookService {
  private readonly apiURL = environment.apiURL;
  constructor(private http: HttpClient) { }

  getAllBooks() {
     return this.http.get<any>(this.apiURL +'/Book').pipe(
     map(response => {return response}));
  }
  subscribeToBook(id: number ){
    this.http.post(this.apiURL+ '/Book/Subscribe', id)
    .subscribe(() => {
      
    }, err => {
      console.log(err);
    })
  }
}
