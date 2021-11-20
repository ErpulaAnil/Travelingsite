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
    [HttpPost, Route("api/Register")]
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
    [HttpGet, Route("api/Login")]
    public IEnumerable<TravelRegister> Login(string _emailid, string _password)
    {

      return _registerservice.TravelLogin(_emailid, _password);


      
    }
  }
}
