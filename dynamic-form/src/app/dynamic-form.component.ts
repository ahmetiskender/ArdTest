import { HttpHeaders } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { UserService } from 'src/services/user.service';

import { QuestionBase } from './question-base';
import { QuestionControlService } from './question-control.service';

@Component({
  selector: 'app-dynamic-form',
  templateUrl: './dynamic-form.component.html',
  providers: [ QuestionControlService ]
})
export class DynamicFormComponent implements OnInit {

  @Input() questions: QuestionBase<string>[] = [];
  form: FormGroup;
  payLoad = '';
  data:{};
  dtOptions: DataTables.Settings = {};
  posts;

  constructor(
    private qcs: QuestionControlService,
    private userService: UserService
    ) {  }

  ngOnInit() {
    this.form = this.qcs.toFormGroup(this.questions);
    this.getUserList();
  }

  onSubmit() {
    this.userService.addUser(this.form.getRawValue())
    .subscribe((res)=>{
      this.getUserList();
    },
    (err)=> {
      this.payLoad=err.message;
    });
  }

  getUserList(){
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      processing: true
    };
    this.userService.getAllUsers()
      .subscribe(posts => {
        this.posts = posts;
    });
  }
}
