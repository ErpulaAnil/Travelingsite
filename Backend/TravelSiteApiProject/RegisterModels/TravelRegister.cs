using System;

namespace RegisterModels
{
    public class TravelRegister
    { 
    public int Id { get; set; }

    public string EmailId { get; set; }

    public long PhoneNumber { get; set; }
    public string CreatePassword { get; set; }

    public string ConfirmPassword { get; set; }

    public string Name { get; set; }
    public string Gender { get; set; }

    public int Age { get; set; }

    public string Nationality { get; set; }
  }
}
