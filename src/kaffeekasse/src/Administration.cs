using System;
using System.IO;
using System.Net.Mail;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Coffee.Types;
using Coffee.Helper;

namespace Coffee {
  public class Administration {
    protected SqlConnection _cnn;
    public SqlConnection cnn {
      get { return _cnn; }
    }
    private string _ip;
    private string _port;
    private string _db;
    private string _user;
    private string _pw;

    public Administration(string ip, string port, string db, string user, string pw) { 
      _ip = ip;
      _port = port;
      _db = db;
      _user = user;
      _pw = pw;
      this.bootstrap();
    }

    private void bootstrap() {
      try {
        string connString = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", this._ip, this._db, this._user, this._pw);
        this._cnn = new SqlConnection(connString);
        Console.WriteLine("Connection Established");
      } catch (Exception ex) {
        Console.WriteLine("Sql Error " + ex);
      }
    }

    public User Login(string username, string password) {
      try {
        this.cnn.Open();
        User foundUser = null;
        string sqlQuery = String.Format("GetUser");
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = sqlQuery;
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@UserName", username));
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();

        if (reader.GetString(reader.GetOrdinal("password")) == password && reader.GetByte(reader.GetOrdinal("isActive")) == 1) {
          foundUser = new User(reader);
        }

        cnn.Close();
        return foundUser;
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error logging in {0}", ex));
        this.cnn.Close();
        return null;
      }
    }

    public List<ItemLog> GetItemLogFromUser(User user) {
      try {
        this.cnn.Open();
        List<ItemLog> list = new List<ItemLog>();
        string sqlQuery = String.Format("GetItemLogFromUser");
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = sqlQuery;
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@UserName", user.username));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
          list.Add(new ItemLog(reader));
        }
        cnn.Close();
        return list;
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error Retriving log from items from Table {0}", ex));
        return null;
      }
    }

    public void SetUserStatus(User user, bool active) {
      try {
        this.cnn.Open();
        string sqlQuery = String.Format("SetUserStatus");
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = sqlQuery;
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Active", Convert.ToByte(active)));
        command.Parameters.Add(new SqlParameter("@UserName", user.username));
        command.ExecuteNonQuery();
        cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error Updateing User Table (isActive)", ex));
      }
    }

    public void UpdateUserAmount(User user, double amount) {
      try {
        this.cnn.Open();
        string sqlQuery = String.Format("UpdateUserAmount");
        SqlCommand command = this.cnn.CreateCommand();
        command.CommandText = sqlQuery;
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Amount", amount));
        command.Parameters.Add(new SqlParameter("@UserName", user.username));
        command.ExecuteNonQuery();
        cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error Updateing User Table (accAmount)", ex));
      }
    }

    public void CsvImport(string path) {
      try {
        var reader = new StreamReader(path);
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          var values = line.Split(';');

          listA.Add(values[0]);
          listB.Add(values[1]);

        }
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error while Import CSV", ex));
      }
    }

    public void CsvExport(string path) {
      try {
        var coffeeLogExport = new CsvExport();

        coffeeLogExport.AddRow();
        coffeeLogExport["Region"] = "Los Angeles, USA";
        coffeeLogExport["Sales"] = 100000;
        coffeeLogExport["Date Opened"] = new DateTime(2003, 12, 31);

        coffeeLogExport.AddRow();
        coffeeLogExport["Region"] = "Canberra \"in\" Australia";
        coffeeLogExport["Sales"] = 50000;
        coffeeLogExport["Date Opened"] = new DateTime(2005, 1, 1, 9, 30, 0);

        coffeeLogExport.ExportToFile(path);


        string myCsv = coffeeLogExport.Export();
        byte[] myCsvData = coffeeLogExport.ExportToBytes();
        // File(myExport.ExportToBytes(), "text/csv", "results.csv");
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error while Export CSV {0}", ex));
      }
    }

    public void SendMail(string toMail, User user) {
      try {
        string address = "mailer@daniel.nehrig.com";
        string smtp = "smtp.strato.de";
        string pop3 = "pop3.strato.de:995";
        string imap = "imap.strato.de:993";
        string username = "mailer";
        string password = "test123123";

        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

        mail.From = new MailAddress(address);
        mail.To.Add(toMail);
        mail.Subject = "Test Mail";
        mail.Body = "This is for testing SMTP mail from GMAIL";

        SmtpServer.Port = 465;
        SmtpServer.Credentials = new System.Net.NetworkCredential(username, password);
        SmtpServer.EnableSsl = true;

        SmtpServer.Send(mail);
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error while Sending Mail {0}", ex));
      }
    }

    public void Logout(User user) {
      try {
        user = null;
      } catch (Exception ex) {
        Console.WriteLine(String.Format("Error while Logout {0}", ex));
      }
    }
  }
}
