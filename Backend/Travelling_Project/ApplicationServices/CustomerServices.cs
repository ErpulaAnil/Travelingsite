using System;
using System.Data.SqlClient;
using ApplicationServices;
using DatabaseConnection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration;
using DatabaseConnection.Exceptions;

namespace ApplicationServices
{
    public class CustomerServices : ICustomerServices
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public CustomerServices()
        {
            _connection = new SqlConnection(ConnectionClass.ConnectionString);
        }

        //This method is used to Take the details from user and also used to store that data into registration by using sql command 
        public bool SignUp(ApplicationRegistration _applicationRegistration)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand($"INSERT INTO dbo.TravelRegistration VALUES ('" +
                    _applicationRegistration.EmailId + "','" + _applicationRegistration.PhnNo + "','" + _applicationRegistration.CreatePassword + "','" +
                    _applicationRegistration.ConfirmPassword + "','" + _applicationRegistration.Name + "','" + _applicationRegistration.Gender + "','" +
                    _applicationRegistration.Age + "','" + _applicationRegistration.Nationality + "')", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

    public bool EmailRegistration(EmailRegistrationClass emailRegistrationClass)
    {
      bool isSuccess = false;
      try
      {
        using (_command = new SqlCommand($"INSERT INTO dbo.EmailRegistration VALUES ('" +
            emailRegistrationClass.UserName + "','" + emailRegistrationClass.PhoneNumber+ "','" + emailRegistrationClass.CreateEmail + "','" +
            emailRegistrationClass.ConfirmEmail + "','" + emailRegistrationClass.CreatePassword + "','" + emailRegistrationClass.ConfirmPassword+ "')", _connection))
        {
          if (_connection.State == System.Data.ConnectionState.Closed)
            _connection.Open();

          _command.ExecuteNonQuery();

          isSuccess = true;
        }
      }
      catch (Exception ex)
      {
        throw new TravellingException(ex.Message, ex);
      }
      finally
      {
        if (_connection.State == System.Data.ConnectionState.Open)
          _connection.Close();
      }

      return isSuccess;
    }

    //This method is used to login the user whose get registered into registration table
    public bool SignIn(ApplicationLogin _applicationLogin)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("SELECT * FROM TravelRegistration where EmailId='" + _applicationLogin.EmailId + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();
                    SqlDataReader Reader=_command.ExecuteReader();
                    while (Reader.Read())
                    {
                        if (_applicationLogin.Password.Equals(Reader[4]))
                        {
                            isSuccess = true;
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }


        //This method is used to check the email Id and get the password from registration table
        public string ForgotPassword(string _email)
        {
            string _password = "";
            try
            {
                using (_command = new SqlCommand("select ConfirmPassword from TravelRegistration where EmailId = '" + _email + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();
                    _password = Convert.ToString(_command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _password;
        }

        //This method is used to get the customer details from TravelRegistration table
        public IEnumerable<ApplicationRegistration> GetRegisteredCustomers()
        {
            List<ApplicationRegistration> _customers = new List<ApplicationRegistration>();

            try
            {
                using (_command = new SqlCommand("SELECT * FROM TravelRegistration", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _customers.Add(new ApplicationRegistration() { EmailId = reader.GetString(1), PhnNo = reader.GetString(2), CreatePassword = reader.GetString(3), ConfirmPassword = reader.GetString(4), Name=reader.GetString(5), Gender=reader.GetString(6), Age=reader.GetString(7), Nationality=reader.GetString(8) });
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _customers;
        }

        //This method is used to get the details from the user and stored into TravelBooking table
        public bool BookingTickets(BookingClass _bookingClass)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand($"INSERT INTO dbo.TravelBooking VALUES ('" + _bookingClass.Name + "','" +
                    _bookingClass.PhnNo + "','" + _bookingClass.FromPlace + "','" + _bookingClass.ToPlace + "','" +
                    _bookingClass.NoOfPassengers + "','" + _bookingClass.DateOfJourney + "','" + _bookingClass.DateOfDeparture + "')", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

        //This method is Used to the cuatomers data from TravelBooking table
        public IEnumerable<BookingClass> GetTicketBookingCustomers()
        {
            List<BookingClass> _bookingCustomers = new List<BookingClass>();

            try
            {
                using (_command = new SqlCommand("SELECT * FROM TravelBooking", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _bookingCustomers.Add(new BookingClass() { Name= reader.GetString(0), PhnNo= reader.GetString(1), FromPlace = reader.GetString(2), ToPlace = reader.GetString(3), NoOfPassengers=reader.GetString(4), DateOfJourney = reader.GetString(5), DateOfDeparture = reader.GetString(6) });
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _bookingCustomers;
        }

        //This method is used to delete selected customer details from the TravelRegistration table
        public bool DeleteAccount(string emailId)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("DELETE from TravelRegistration where EmailId = '" + emailId + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

        //This method is used to delete selected customer details from the TravelBooking table 
        public bool CancelBooking(string name)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("DELETE from TravelBooking where Name = '" + name + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

        //This method is used to Update the CreatePassword and ConfirmPassword based on customer EmailId
        public bool ResetPassword(ResetPasswordClass _resetPassword)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand("Update TravelRegistration set CreatePassword = '" + _resetPassword.Password + "' , ConfirmPassword='"+ _resetPassword.Password +"'  where EmailId='"+ _resetPassword.Email +"' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }

        //This methos is used to Update the Specific columns
        public bool EditProfile(EditProfileClass _editProfileClass)
        {
            bool isSuccess = false;
            try
            {
                using (_command = new SqlCommand($"Update TravelRegistration set EmailId='" + _editProfileClass.EmailId + "',PhnNO='" + _editProfileClass.PhnNo + "',Name='" +
                     _editProfileClass.Name + "',Gender='" + _editProfileClass.Gender + "', Age='" + 
                    _editProfileClass.Age + "',Nationality='" + _editProfileClass.Nationality + "' where EmailId = '"+ _editProfileClass.OldEmail + "'  ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new TravellingException(ex.Message, ex);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return isSuccess;
        }
    }
}
