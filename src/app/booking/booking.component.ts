/**
 * @description The below code is used to give access to the user to book tickets
 * importing  Component, OnInit  from '@angular/core
 * importing html and css from about booking folder
 */
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiService } from '../shared/api.service';
import { UserModel } from '../shared/model/user.model';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {
  public data = {
    name: "",
    phonenumber: "",
    from: "",
    to: "",
    noofpassengers: "",
    dateofjourney: "",
    dateofdeparture: "",

  }
  public bookingObj = new UserModel();

  constructor(private http: HttpClient, private router: Router, private api: ApiService) { }

  ngOnInit(): void {
  }
  Booking() {
    const formData = new FormData();
    
    formData.append("Name",this.data.name)
    formData.append("Phonenumber",this.data.phonenumber)
    formData.append("From",this.data.from)
    formData.append("To",this.data.to)
    formData.append("Noofpassengers",this.data.noofpassengers)
    formData.append("Dateofjourney",this.data.dateofjourney)
    formData.append("Dateofdeparture",this.data.dateofdeparture)

    

    console.log(this.bookingObj)
    this.api.Booking(formData)
      .subscribe(res => {
        alert("success");
      })
  }
}

