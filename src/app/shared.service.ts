import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "http://localhost:47667/api/Travel";
    constructor(private http: HttpClient) {}
    Register(): Observable < any[] > {
        return this.http.get < any > (this.APIUrl + '/Register');
    }
    Login(val: any) {
        return this.http.post(this.APIUrl + '/Login', val);
    }
    ForgotPWd(val: any) {
        return this.http.put(this.APIUrl + '/ForgotPassword', val);
    }
    DeletingAccount(id: any) {
        return this.http.delete(this.APIUrl + '/DeleteAccount/' + id);
    }
    Booking(): Observable<any[]> {
        return this.http.get<any>(this.APIUrl + '/TicketBooking');
    }
    GetRegisteredCustomers(): Observable < any[] > {
        return this.http.get<any>(this.APIUrl + '/GetRegisteredCustomers');
    }
    GetTicketBookingCustomers(): Observable<any[]> {
        return this.http.get<any>(this.APIUrl + '/GetBookingCustomers');
    }
    CancelingBooking(val: any) {
        return this.http.post(this.APIUrl + '/CancelBooking', val);
    }
    ResettingPassword(val: any) {
        return this.http.put(this.APIUrl + '/ResetPassword', val);
    }
}
