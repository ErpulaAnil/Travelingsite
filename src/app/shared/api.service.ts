import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { pipe } from 'rxjs';
import {map} from 'rxjs/operators'
@Injectable({
  providedIn: 'root'
})
export class ApiService{

  readonly APIUrl = "http://localhost:47667/api/Travel";

  constructor(private _http : HttpClient) { }

 
  Register(empObj : any){
    console.log("empobj.....",empObj);
    //return this._http.post<any>(this.loginAPIUrl+"signup",empObj)
    return this._http.post<any>(this.APIUrl + '/Register' ,empObj)
  }
  Login(empObj:any){
    return this._http.get<any>(this.APIUrl + '/Login' ,empObj)
  }
  Booking(empObj : any){
    console.log("empobj.....",empObj); 
    return this._http.post<any>(this.APIUrl + '/TravelBooking' ,empObj)
  }
  
}