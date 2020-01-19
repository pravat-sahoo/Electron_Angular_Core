import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DemoService {
  baseUrl = 'localhost://5000';

  constructor( private http: HttpClient) {

   }
   getContacts(){
     return this.http.get("http://localhost:5000/api/Student");
   }
}
