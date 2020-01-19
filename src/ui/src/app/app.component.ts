import { Component } from '@angular/core';
import { DemoService } from './core/services/demo.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ui';
  studentList: any;
constructor(private demoService: DemoService) {
this.getAllStudents();
}
  getAllStudents() {
  this.demoService.getContacts().subscribe(result => {
  this.studentList = result;
  });
  }
}
