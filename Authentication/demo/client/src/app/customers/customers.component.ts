import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: []
})
export class CustomersComponent implements OnInit {

  customers: any;
 
  constructor(private http: HttpClient) { }
 
  ngOnInit() {
    this.http.get("https://localhost:5000/weatherforecast", {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      this.customers = response;
    }, err => {
      console.log(err)
    });

  }
}
