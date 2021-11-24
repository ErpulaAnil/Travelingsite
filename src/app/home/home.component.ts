/**
 * @description The below code is used to display the landing page
 * importing  Component, OnInit  from '@angular/core
 * importing html and css from about home folder
 */
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
