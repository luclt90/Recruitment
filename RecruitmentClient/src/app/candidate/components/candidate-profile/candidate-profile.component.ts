import { Component, OnInit } from '@angular/core';
import { UserInfo } from 'src/app/_models/user-info';

@Component({
  selector: 'app-candidate-profile',
  templateUrl: './candidate-profile.component.html',
  styleUrls: ['./candidate-profile.component.css']
})
export class CandidateProfileComponent implements OnInit {
  userInfo: UserInfo = JSON.parse(localStorage.getItem('userInfo'));
  constructor() { }

  ngOnInit() {
  }

}
