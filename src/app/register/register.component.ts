import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  name = '';
  email = '';
  password = '';
  confirmPassword = '';
  phonenumber = '';
  valid = { name: true, email: true, password: true, phonenumber: true };

  constructor() { }

  ngOnInit(): void { }

  validate(type: string): void { 
    const namePattern = /^[\w- .]*$/; 
    const emailPattern = /\S+@\S+\.\S+/;
    const phonenumberPattern = /^[\w- .]*$/; 
    
    if (type === 'name') { 
      if (this.name.length < 5) { 
        this.valid.name = false; } else {
           this.valid.name = namePattern.test(this.name); 
          } 
        } else if (type === 'email') { 
          this.valid.email = emailPattern.test(this.email); 
        } else if (type === ('confirmPassword' || 'password')) { 
          if (this.password !== this.confirmPassword) { 
            this.valid.password = false; 
          } else { 
            this.valid.password = true; 
          } 
        } else if (type === 'phonenumber') { 
          this.valid.phonenumber = phonenumberPattern.test(this.email); 
        }
      } 
      onKey(event: any, type: string) { 
        if (type === 'name') { 
          this.name = event.target.value; 
        } else if (type === 'email') { 
          this.email = event.target.value; 
        } else if (type === 'phonenumber') { 
          this.phonenumber = event.target.value;
        } else if (type === 'password') { 
          this.password = event.target.value; 
        } else if (type === 'confirmPassword') { 
          this.confirmPassword = event.target.value; 
        } this.validate(type); 
    }
    
    
}

