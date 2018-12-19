using System;
using System.Data;
using System.Data.SqlClient;

namespace BKTMManager.Controller {
  abstract class IOController {
    protected string _ip;
    protected string _db;
    protected string _user;
    protected string _pw;
    protected SqlConnection _cnn = null;

    public SqlConnection cnn {
      get { return _cnn; }
    }

    // Default Constructor
    public IOController(string ip, string db, string user, string pw) {
      this._ip = ip;
      this._db = db;
      this._user = user;
      this._pw = pw;
      this.initConnection();
    }

    /*
     * @return bool
     */
    protected bool initConnection() {
      string connetionString = null;
      connetionString = "Data Source=" + this._ip + ";Initial Catalog=" + this._db + ";User ID=" + this._user + ";Password=" + this._pw;
      this._cnn = new SqlConnection(connetionString);
      try {
        _cnn.Open();
        Console.WriteLine("Connection Open!");
        return true;
      }
      catch (Exception ex) {
        Console.WriteLine("Can not open connection!" + ex);
        return false;
      }
    }
    
    /*
     * @return bool
     */
    protected bool openConnection() {
      try {
        _cnn.Open();
        return true;
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return false;
      }
    }

    /*
     * @return bool
     */
    protected bool closeConnection() {
      try {
        _cnn.Close();
        Console.WriteLine("Connection Closed!");
        return true;
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return false;
      }
    }
  }
}
