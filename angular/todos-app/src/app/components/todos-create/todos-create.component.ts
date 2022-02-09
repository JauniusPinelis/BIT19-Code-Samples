import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-todos-create',
  templateUrl: './todos-create.component.html',
  styleUrls: ['./todos-create.component.css']
})
export class TodosCreateComponent implements OnInit {
  @Output() todoCreateEvent = new EventEmitter<string>();
  public todoName: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  public createTodo(){
    this.todoCreateEvent.emit(this.todoName);
  }

}
