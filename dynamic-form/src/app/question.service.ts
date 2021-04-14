import { Injectable } from '@angular/core';

import { DropdownQuestion } from './question-dropdown';
import { QuestionBase } from './question-base';
import { TextboxQuestion } from './question-textbox';
import { of } from 'rxjs';

@Injectable()
export class QuestionService {

  // TODO: get from a remote source of question metadata
  getQuestions() {

    const questions: QuestionBase<string>[] = [

      new DropdownQuestion({
        key: 'Gender',
        label: 'Cinsiyet',
        required: true,
        options: [
          {key: '0',  value: 'Erkek'},
          {key: '1',  value: 'Kadın'},
          {key: '2',   value: 'Diğer'}
        ],
        order: 3
      }),

      new TextboxQuestion({
        key: 'FullName',
        label: 'Tam İsim',
        required: true,
        order: 1
      }),

      new TextboxQuestion({
        key: 'Email',
        label: 'Email',
        type: 'email',
        required: true,
        order: 2
      }),

      new TextboxQuestion({
        key: 'ImgPath',
        label: 'Resim',
        type: 'file',
        required: true,
        order: 4
      })
    ];

    return of(questions.sort((a, b) => a.order - b.order));
  }
}
