import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import Todo from 'src/app/models/todo.model';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-todos-list',
  templateUrl: './todos-list.component.html',
  styleUrls: ['./todos-list.component.css']
})
export class TodosListComponent implements OnInit {
  public todosInput: Todo[] = [];
  constructor(private stateService: StateService) { }

  ngOnInit(): void {
    this.stateService.loadAll();
    
    this.stateService.todos$.subscribe((todosData) => {
      this.todosInput = todosData;
    })
  }

  public removeTodo(todoId: number){
    this.stateService.delete(todoId);
  }

}
