using System;
using System.Collections.Generic;
using System.Text;
using RegisterModels;
using SqlConnectionClass;
namespace TravelRepository
{
 public interface IRegisterService
    {
   
    bool JoinNow(TravelRegister _travelRegister);
   // bool Login(string _emailid,string _password);
    IEnumerable<TravelRegister> TravelLogin(string _emailid, string _password);

    bool ForgetPassword(string _confirmpassword);

  //  bool BookingTicket(TravelRegister _travelRegister);

  }
}
