/**
 * @description The below code is used to change the password
 * importing  Component, OnInit  from '@angular/core'
 * importing Swal from 'sweetalert2'
 * importing html and css from about password folder
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { UserModel } from '../shared/model/user.model';
import { HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.css']
})

/**
 * @description : created a class component with the name PasswordComponent  
 * shows the booking data 
 * @params : {string}
 * @returns : non
 */
export class PasswordComponent implements OnInit {
  public data = {
    email: "",
    password: "",
  }


  valid = {
    email: true,
  }

  public passwordObj = new UserModel();
  constructor(private http: HttpClient, private router: Router, private api: ApiService) { }

  ngOnInit(): void {
  }
  validate(type: string): void {
    const emailPattern = /\S+@\S+\.\S+/;

    if (type === 'email') {
      this.valid.email = emailPattern.test(this.data.email);
    }
  }

  //onkey function
  onkey(event: any, type: string) {
    if (type === 'email') {
      this.data.email = event.target.value;
    }
    this.validate(type)
  }
  successNotification() {
    Swal.fire('Password has been successfully updated', 'We have been informed!', 'success')
  }
  Password() {
    const formData = new FormData();
    formData.append("Emailid", this.data.email)
    formData.append("CreatePassword", this.data.password)


    console.log(this.passwordObj)
    this.api.Register(formData)
      .subscribe(res => {
        alert("success");
      })
  }
}

