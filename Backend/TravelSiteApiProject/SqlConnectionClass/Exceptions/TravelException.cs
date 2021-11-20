using System;
using System.Collections.Generic;
using System.Text;

namespace SqlConnectionClass.Exceptions
{
  public class TravelException:Exception
  {
    public TravelException()
    {

    }

    public TravelException(string message) : base(message)
    {

    }

    public TravelException(string message, Exception innerEx) : base(message, innerEx)
    {

    }
  }
}
