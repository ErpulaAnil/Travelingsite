import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { BookingComponent } from './booking/booking.component';
import { PasswordComponent } from './password/password.component';
import { CheckComponent } from './check/check.component';
import { PassengerInfoComponent } from './passenger-info/passenger-info.component';



const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'booking',component:BookingComponent},
  {path:'about',component:AboutComponent},
  {path:'password',component:PasswordComponent},
  {path:'check',component:CheckComponent},
  {path:'passenger-info',component:PassengerInfoComponent}
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
