import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-register',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  email = "";

  valid = {
  email : true,
  }
  constructor() { }

  ngOnInit(): void {
  }
  //validation part
  validate(type: string): void {
    const emailPattern = /\S+@\S+\.\S+/;
    if (type === 'email') {
      this.valid.email = emailPattern.test(this.email);
    } 
  }

  //onkey function
    onkey(event:any , type:string){
      if( type === "email"){
        this.email = event.target.value;
      }
      this.validate(type)
    }
}