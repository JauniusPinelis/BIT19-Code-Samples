import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import Todo from 'src/app/models/todo.model';

@Component({
  selector: 'app-todos-list',
  templateUrl: './todos-list.component.html',
  styleUrls: ['./todos-list.component.css']
})
export class TodosListComponent implements OnInit {
  @Input() todosInput: Todo[] = [];
  @Output() removeTodoEvent = new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }

  public removeTodo(todoId: number){
    this.removeTodoEvent.emit(todoId);
  }

}
