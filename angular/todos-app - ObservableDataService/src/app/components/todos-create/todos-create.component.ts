import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import TodoCreate from 'src/app/models/todo-create.model';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-todos-create',
  templateUrl: './todos-create.component.html',
  styleUrls: ['./todos-create.component.css']
})
export class TodosCreateComponent implements OnInit {
  public todoName: string = '';

  constructor(private stateService: StateService) { }

  ngOnInit(): void {
  }

  public createTodo(){
    let todoCreate: TodoCreate = {
      name: this.todoName
    };

    this.stateService.create(todoCreate);
  }

}
