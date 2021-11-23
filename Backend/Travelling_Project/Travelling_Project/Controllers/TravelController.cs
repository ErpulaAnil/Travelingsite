using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using ApplicationServices;
using DatabaseConnection.Exceptions;
using Registration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travelling_Project.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]

    public class TravelController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        public TravelController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        //Generating the EndPoint for SignUp
        [HttpPost, Route("api/Travel/Register")]
        public bool Register(ApplicationRegistration _applicationRegistration)
        {
            if (_customerServices.SignUp(_applicationRegistration))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Generating the EndPoint for SignIn
        [HttpGet, Route("api/Travel/Login")]
        public bool Login(ApplicationLogin _applicationLogin)
        {
            if (_customerServices.SignIn(_applicationLogin))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Generating the EndPoint for ForgotPassword
        [HttpGet, Route("api/Travel/ForgotPassword")]
        public string ForgotPWd(string _email)
        { 
            return _customerServices.ForgotPassword(_email);            
        }

        //Generating the EndPoint for GetRegisteredCustomers
        [HttpGet, Route("api/Travel/GetRegisteredCustomers")]
        public IEnumerable<ApplicationRegistration> GetRegisteredCustomers()
        {
            return _customerServices.GetRegisteredCustomers();
        }

        //Generating the EndPoint for TicketBooking
        [HttpPost, Route("api/Travel/TicketBooking")]
        public bool Booking(BookingClass _bookingClass)
        {
            if (_customerServices.BookingTickets(_bookingClass))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Generating the EndPoint for GetBookingCustomers
        [HttpGet, Route("api/Student/GetBookingCustomers")]
        public IEnumerable<BookingClass> GetTicketBookingCustomers()
        {
            return _customerServices.GetTicketBookingCustomers();
        }

        //Generating the EndPoint for DeleteAccount
        [HttpDelete, Route("api/Travel/DeleteAccount")]
        public bool DeletingAccount(string emailId)
        {
            if (_customerServices.DeleteAccount(emailId))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Generating the EndPoint for CancelBooking
        [HttpDelete, Route("api/Travel/CancelBooking")]
        public bool CancelingBooking(string Name)
        {
            if (_customerServices.CancelBooking(Name))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Generating the EndPoint for ResetPassword
        [HttpPatch,Route("api/Travel/ResetPassword")]
        public bool ResettingPassword(ResetPasswordClass resetPassword)
        {
            if (_customerServices.ResetPassword(resetPassword))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Generating the EndPoint for EditProfile
        [HttpPut, Route("api/Travel/EditProfile")]
        public bool EditingProfile(EditProfileClass _editProfileClass)
        {
            if (_customerServices.EditProfile(_editProfileClass))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }  
}
