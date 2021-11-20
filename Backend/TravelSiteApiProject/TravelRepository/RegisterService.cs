using System;
using System.Collections.Generic;
using System.Text;
using RegisterModels;
using System.Data.SqlClient;
using SqlConnectionClass;
using SqlConnectionClass.Exceptions;

namespace TravelRepository
{
  public class RegisterService : IRegisterService
  {
    private SqlConnection _connection;
    private SqlCommand _command;

    public RegisterService()
    {
      _connection = new SqlConnection(SqlconnectionString.ConnectionString);
    }
    public bool JoinNow(TravelRegister _travelRegister)
    {
      bool isSuccess = false;
      try
      {
        using (_command = new SqlCommand($"INSERT INTO RegisterTable (EmailId,PhoneNumber,CreatePassword,ConfirmPassword,Name,Gender,Age,Nationality) VALUES ('{_travelRegister.EmailId}', {_travelRegister.EmailId}',{_travelRegister.PhoneNumber}',{_travelRegister.CreatePassword}',{_travelRegister.ConfirmPassword}',{_travelRegister.Name}',{_travelRegister.Gender}',{_travelRegister.Age}',{_travelRegister.Nationality})", _connection))
        {
          if (_connection.State == System.Data.ConnectionState.Closed)
            _connection.Open();

          _command.ExecuteNonQuery();

          isSuccess = true;
        }
      }
      catch (Exception ex)
      {
        throw new TravelException(ex.Message, ex);
      }
      finally
      {
        if (_connection.State == System.Data.ConnectionState.Open)
          _connection.Close();
      }

      return isSuccess;
    }


    public IEnumerable<TravelRegister> TravelLogin(string _emailid, string _password)
    {


      List<TravelRegister> _travelrigister = new List<TravelRegister>();

      try
      {
        using (_command = new SqlCommand("SELECT * FROM RegisterTable where EmailId='"+ _emailid + "' ConfirmPassword='"+_password+"'", _connection))
        {
          if (_connection.State == System.Data.ConnectionState.Closed)
            _connection.Open();

          SqlDataReader reader = _command.ExecuteReader();

          while (reader?.Read() ?? false)
            _travelrigister.Add(new TravelRegister() { Id = reader.GetInt32(0), EmailId = reader.GetString(1), PhoneNumber = reader.GetInt32(2), CreatePassword = reader.GetString(3), ConfirmPassword = reader.GetString(4), Name = reader.GetString(5), Gender = reader.GetString(6), Age = reader.GetInt32(7), Nationality = reader.GetString(8) });
        }
      }
      catch (Exception ex)
      {
        throw new TravelException(ex.Message, ex);
      }
      finally
      {
        if (_connection.State == System.Data.ConnectionState.Open)
          _connection.Close();
      }

      return _travelrigister;
    }

  
  }
}
