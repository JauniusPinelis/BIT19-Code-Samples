import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { TodosComponent } from './components/todos/todos.component';
import { TodosListComponent } from './components/todos-list/todos-list.component';
import { TodosCreateComponent } from './components/todos-create/todos-create.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TodosComponent,
    TodosListComponent,
    TodosCreateComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
