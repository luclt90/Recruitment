import { ViewportScroller } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(private scroll: ViewportScroller) { }

  ngOnInit() {
  }

  scrollToTop(){
    this.scroll.scrollToPosition([0,0]);
  }
}
