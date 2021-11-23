using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnection.Exceptions
{
    public class TravellingException : Exception
    {
        public TravellingException()
        {

        }

        public TravellingException(string message) : base(message)
        {

        }

        public TravellingException(string message, Exception innerEx) : base(message, innerEx)
        {

        }
    }
}
