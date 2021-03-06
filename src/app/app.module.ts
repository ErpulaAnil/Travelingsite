import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BookingComponent } from './booking/booking.component';
import { AboutComponent } from './about/about.component';
import { PasswordComponent } from './password/password.component';
import { CheckComponent } from './check/check.component';
import { PassengerInfoComponent } from './passenger-info/passenger-info.component';
import { HttpClientModule } from "@angular/common/http";
import { ApiService } from './shared/api.service';
import { FormsModule,ReactiveFormsModule } from "@angular/forms";




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    BookingComponent,
    AboutComponent,
    PasswordComponent,
    CheckComponent,
    PassengerInfoComponent,
    
    

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule

  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})

export class AppModule { }
