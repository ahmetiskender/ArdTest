import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { DynamicFormComponent } from './dynamic-form.component';
import { DynamicFormQuestionComponent } from './dynamic-form-question.component';
import { from } from 'rxjs';
import { UploadComponent } from './upload/upload.component';
import { DataTablesModule } from 'angular-datatables';

@NgModule({
  imports: [ BrowserModule, ReactiveFormsModule,HttpClientModule,DataTablesModule ],
  declarations: [ AppComponent, DynamicFormComponent, DynamicFormQuestionComponent, UploadComponent ],
  bootstrap: [ AppComponent ],
  providers:[
    {provide:'apiUrl',useValue:'https://localhost:5001/api/User'}
  ]
})
export class AppModule {
  constructor() {
  }
}
