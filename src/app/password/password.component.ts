import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.css']
})
export class PasswordComponent implements OnInit {
  email = '';

  valid ={
    email : true,
  }

  constructor() { }

  ngOnInit(): void {
  }
  validate(type: string): void {
    const emailPattern = /\S+@\S+\.\S+/;

    if (type === 'email') {
      this.valid.email = emailPattern.test(this.email);
    }
  }

  //onkey function
  onkey(event: any, type: string) {
    if (type === 'email') {
      this.email = event.target.value;
    }
    this.validate(type)
  }
  successNotification(){
    Swal.fire('Password has been successfully updated', 'We have been informed!', 'success')
  }
}

