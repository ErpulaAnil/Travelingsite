import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  username = "";
  email = "";
  phonenumber = "";
  password = "";
  confirmPassword = "";

  valid = {
  username : true,
  lastname : true,
  email : true,
  phonenumber : true,
  password : true,
  confirmPassword : true,
  }
  constructor() { }

  ngOnInit(): void {
  }
  //validation part
  validate(type: string): void {
    const usernamePattern = /^[a-zA-Z]+$/
    const emailPattern = /\S+@\S+\.\S+/;
    const mobilePattern = /^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$/;
    if (type === 'username') {
      if (this.username.length < 3 || this.username.length>=10) {
        this.valid.username = false;
      } else {
        this.valid.username = usernamePattern.test(this.username);
      }
    } else if(type === "phonenumber"){
      if(this.phonenumber.length<10 || this.phonenumber.length>10){
        this.valid.phonenumber = false
      }else{
          this.valid.phonenumber = mobilePattern.test(this.phonenumber)
      }
    }
     else if (type === 'email') {
      this.valid.email = emailPattern.test(this.email);
    } else if (type === ('confirmPassword' || 'password')) {
      if (this.password !== this.confirmPassword) {
        this.valid.password = false;
      } else {
        this.valid.password = true;
      }
    }
  }

  //onkey function
    onkey(event:any , type:string){
      if(type === 'username'){
       this.username = event.target.value;
      }else if( type === "email"){
        this.email = event.target.value;
      }else if (type === "password"){
        this.password = event.target.value;
      }else if (type === "confirmPassword"){
        this.confirmPassword = event.target.value;
      }else if (type === "phonenumber"){
        this.phonenumber = event.target.value;
      }
      this.validate(type)
    }
}