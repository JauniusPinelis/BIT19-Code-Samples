import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import TodoCreate from '../models/todo-create.model';
import Todo from '../models/todo.model';

@Injectable({
  providedIn: 'root'
})
export class TodosService {

  constructor(private httpClient: HttpClient) { }

  public getAll() : Observable<Todo[]> {
    return this.httpClient.get<Todo[]>('https://localhost:44338/todo');
  }

  public create(todoCreate: TodoCreate) : Observable<number> {
    return this.httpClient.post<number>('https://localhost:44338/todo', todoCreate);
  }
}
