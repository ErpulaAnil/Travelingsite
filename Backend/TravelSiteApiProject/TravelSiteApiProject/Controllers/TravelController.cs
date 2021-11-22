using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterModels;
using TravelRepository;

namespace TravelSiteApiProject.Controllers
{
  // [Route("api/[controller]")]
  //[ApiController]


  public class TravelController : ControllerBase
  {

    private readonly IRegisterService _registerservice;
    public TravelController(IRegisterService registerservice)
    {
      _registerservice = registerservice;
    }
    [HttpPost, Route("api/Travel/Register")]
    public bool Register(TravelRegister _travelregister)
    {
      if (_registerservice.JoinNow(_travelregister))
      {
        return true;
      }

      else
      {
        return false;
      }
    }
    [HttpGet, Route("api/Travel/Login/{_emailid}/{_password}")]
    public IEnumerable<TravelRegister> Login(string _emailid, string _password)
    {

      return _registerservice.TravelLogin(_emailid, _password);

    }
    [HttpPost, Route("api/Travel/ForgetPassword/{_confirmpassword}")]
    public bool ForgetPassword(string _confirmpassword)
    {
      if (_registerservice.ForgetPassword(_confirmpassword))
      {
        return _registerservice.ForgetPassword(_confirmpassword);
      }

      return true;
      
    }
    //[HttpGet, Route("api/Student/UpdateToNextClass/{rollNumber}")]
    //public IEnumerable<Student> UpdateToNextClass(int rollNumber)
    //{
    //  if (_studentService.UpdateStudentToNextClass(rollNumber))
    //  {
    //    return _studentService.GetStudentsListFromDataBase().Where(s => s.RollNumber == rollNumber);
    //  }

    //  return Enumerable.Empty<Student>();
    //}
  }
}
