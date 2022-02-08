import { Component, OnInit } from '@angular/core';
import Todo from 'src/app/models/todo.model';
import { TodosService } from 'src/app/services/todos.service';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css']
})
export class TodosComponent implements OnInit {
  public todos: Todo[] = [];

  constructor(private todosService: TodosService) { }

  ngOnInit(): void {
    this.todosService.getAll().subscribe((todosData) => {
      this.todos = todosData;
      console.log(this.todos);
    })
  }

  public createTodo(todoEvent: any): void {
    let todo: Todo = {
      id: 5, 
      name: todoEvent
    }

    this.todos.push(todo);
    console.log("Add Todo is called");
  }

  public removeTodo(removeTodoEvent: any): void {
    let id = removeTodoEvent;
    // service call
    this.todos = this.todos.filter(t => t.id != id);
  }

}
