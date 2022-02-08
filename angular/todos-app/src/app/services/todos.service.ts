import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import Todo from '../models/todo.model';

@Injectable({
  providedIn: 'root'
})
export class TodosService {

  constructor(private httpClient: HttpClient) { }

  public getAll() : Observable<Todo[]> {
    return this.httpClient.get<Todo[]>('https://localhost:44338/todo');
  }
}
