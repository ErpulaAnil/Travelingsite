/**
 * @description The below code is used to register
 * importing  Component, OnInit  from '@angular/core'
 * importing html and css from about register folder
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { UserModel } from '../shared/model/user.model';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

/**
 * @description : created a class component with the name RegisterComponent  
 * validates the information given by the user
 * @params : {string}
 * @return : non
 */
export class RegisterComponent implements OnInit {
  public data = {
  username : "",
  email : "",
  phonenumber : "",
  password : "",
  confirmPassword : "",
  age : "",
  }
  valid = {
    username: true,
    lastname: true,
    email: true,
    phonenumber: true,
    password: true,
    confirmPassword: true,
    age: true,
  }
  public registerObj = new UserModel();
  constructor( private http : HttpClient,private router : Router, private api: ApiService) { }

  ngOnInit(): void {
  }
  //validation part
  validate(type: string): void {
    const usernamePattern = /^[a-zA-Z]+$/
    const emailPattern = /\S+@\S+\.\S+/;
    const mobilePattern = /^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$/;
    const agePattern = /[0-9]/
    if (type === 'username') {
      if (this.data.username.length < 4 || this.data.username.length >= 10) {
        this.valid.username = false;
      } else {
        this.valid.username = usernamePattern.test(this.data.username);
      }
    } else if (type === "phonenumber") {
      if (this.data.phonenumber.length < 10 || this.data.phonenumber.length > 10) {
        this.valid.phonenumber = false
      } else {
        this.valid.phonenumber = mobilePattern.test(this.data.phonenumber)
      }
    } else if (type === "age") {
      if (this.data.age.length < 2 || this.data.age.length > 2) {
        this.valid.age = false
      } else {
        this.valid.age = agePattern.test(this.data.age)
      }
    }
    else if (type === 'email') {
      this.valid.email = emailPattern.test(this.data.email);
    } else if (type === ('confirmPassword' || 'password')) {
      if (this.data.password !== this.data.confirmPassword) {
        this.valid.password = false;
      } else {
        this.valid.password = true;
      }
    }
  }


  //onkey function which is used to connect to the html file
  onkey(event: any, type: string) {
    if (type === 'username') {
      this.data.username = event.target.value;
    } else if (type === "email") {
      this.data.email = event.target.value;
    } else if (type === "password") {
      this.data.password = event.target.value;
    } else if (type === "confirmPassword") {
      this.data.confirmPassword = event.target.value;
    } else if (type === "phonenumber") {
      this.data.phonenumber = event.target.value;
    } else if (type === "age") {
      this.data.age = event.target.value;
    }
    this.validate(type)
  }
  Register(){
  this.registerObj.UserName = this.data.username;
  this.registerObj.Emailid = this.data.email;
  this.registerObj.CreatePassword = this.data.password;
  this.registerObj.ConfirmPassword = this.data.phonenumber;
  this.registerObj.Name = this.data.confirmPassword;
  this.registerObj.Age = this.data.age;

  console.log(this.registerObj)
  this.api.Register(this.registerObj)
  .subscribe(res =>{
    alert("success");
  })
  }
}