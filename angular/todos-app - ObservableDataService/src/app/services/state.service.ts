import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import TodoCreate from '../models/todo-create.model';
import Todo from '../models/todo.model';
import { TodosService } from './todos.service';

@Injectable({
  providedIn: 'root',
})
export class StateService {
  // We will use this to transmit updated Todos
  public todos$ = new BehaviorSubject<Todo[]>([]);

  // this is the variable that component will subscribe to
  //public todos$ = this._todos.asObservable();

  private todos: Todo[] = [];

  constructor(private todosService: TodosService) {}

  public loadAll() {
    this.todosService.getAll().subscribe((todos) => {
      this.todos = todos;
      this.todos$.next(this.todos);
    });
  }

  public create(todoCreate: TodoCreate) {
    this.todosService.create(todoCreate).subscribe((todo) => {
     
      this.todos.push(todo);

      this.todos$.next(this.todos);
    });
  }

  public delete(id: number) {
    this.todosService.delete(id).subscribe(() => {
      this.todos = this.todos.filter((t) => t.id !== id);
      this.todos$.next(this.todos);
    });
  }
}
