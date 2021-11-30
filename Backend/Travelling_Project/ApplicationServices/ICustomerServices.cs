using System;
using Registration;
using System.Collections.Generic;

namespace ApplicationServices
{
    public interface ICustomerServices
    {
       bool SignUp(ApplicationRegistration _applicationRegistration);

       bool SignIn(ApplicationLogin _applicationLogin);

       string ForgotPassword(string _email);

       IEnumerable<ApplicationRegistration> GetRegisteredCustomers();

       bool BookingTickets(BookingClass _bookingClass);

       IEnumerable<BookingClass> GetTicketBookingCustomers();

       bool DeleteAccount(string emailID);

       bool CancelBooking(string Name);

       bool ResetPassword(ResetPasswordClass _resetPassword);

       bool EditProfile(EditProfileClass _editProfileClass);

      bool EmailRegistration(EmailRegistrationClass emailRegistrationClass);
  }
}
