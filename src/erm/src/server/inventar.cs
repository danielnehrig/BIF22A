using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Inventory {
  /*
   * Description : Helper Class
   */
  class Config {
    public Dictionary<string, string> cnnInfo = new Dictionary<string, string>();

    /*
     * Description : Read config and save to dictionary
     * @param <string> config
     * @return bool
     */
    public bool read(string config) {
      try {
        cnnInfo = File.ReadAllLines(config)
        .Select(l => l.Split(new[] { '=' }))
        .ToDictionary( s => s[0].Trim(), s => s[1].Trim());
        return true;
      } catch (Exception ex) {
        Console.WriteLine("Couldn't Read Config file\n does it exist inside the same folder?", ex);
        return false;
      }
    }

    public Config(string config) {
      this.read(config);
    }
  }

  /**
   * Description : Main Logic
   */
  class Program {
    public static int Main(string[] args) {
      try {
        // Read the Config
        Config config = new Config("config.cfg");
        // Load DeviceAdmin manager
        DeviceAdministration inventory = new DeviceAdministration(config.cnnInfo["ip"], config.cnnInfo["db"], config.cnnInfo["user"], config.cnnInfo["pw"]);
        inventory.getRoomById("1");
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 0;
      }
      return 1;
    }
  }

  /**
   * Description : IOController Database controller
   */
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

  class Room {
    private List<Device> _devices = new List<Device>();
    public Device getDevice(string id) {
      return _devices.Find(x => x.id.Contains(id));
    }
  }

  class UserAdministration : IOController {
    public UserAdministration(string ip, string db, string user, string pw):base(ip, db, user, pw) {
    }

    public void createUser(string type) {
      if (type == "admin") {
      } else {
      }
    }
  }

  class DeviceAdministration : IOController {
    private List<Admin> _admins = new List<Admin>();
    public List<Admin> admins {
      set { _admins = value; }
      get { return _admins; }
    }

    private List<HardwareComponent> _hwComp = new List<HardwareComponent>();
    public List<HardwareComponent> hwComp {
      set { _hwComp = value; }
      get { return _hwComp; }
    }

    private List<Device> _device = new List<Device>();
    public List<Device> device { 
      set { _device = value; }
      get { return _device; }
    }

    // extend the DeviceAdministration Constructor from inherited class IOController
    public DeviceAdministration(string ip, string db, string user, string pw):base(ip, db, user, pw) {
      // Todo
    }

    public void addHardwareComponent(string name, float price) {
      _hwComp.Add(new HardwareComponent(name, price));
    }

    public void addDevice(string name, List<HardwareComponent> components) {
      _device.Add(new Device(name, components));
    }

    public HardwareComponent getHardwareComponent(string id) {
      return _hwComp.Find(x => x.id.Contains(id));
    }

    /*
     * Description - get the Device object from the given ID
     * @param <string> id - Device id from DB
     * @return void
     */
    public void getDeviceById(string id) {
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Geräte] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          Console.WriteLine(String.Format("{0}", reader[0]));
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      // return _device.Find(x => x.id.Contains(id));
    }

    /*
     * Description - get the Room Name from the given ID
     * @param <string> id - room id from DB
     * @return void
     */
    public void getRoomById(string id) {
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Räume] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          Console.WriteLine(String.Format("{0}", reader[0]));
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      // return _device.Find(x => x.id.Contains(id));
    }
  }

  class Device {
    private string _id;
    public string id {
      get { return _id; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    private List<HardwareComponent> _hwComp = new List<HardwareComponent>();
    public List<HardwareComponent> hwComp {
      set { _hwComp = value; }
      get { return _hwComp; }
    }

    public Device(string name, List<HardwareComponent> components) {
      this._name = name;
      this._hwComp = components;
    }

    public float sumOfComponents() {
      float sum = 0;
      foreach (HardwareComponent Component in _hwComp) {
        sum += Component.price;
      }
      return sum;
    }
  }

  class HardwareComponent {
    private string _id;
    public string id {
      get { return _id; }
    }

    private string _name;
    public string name {
      set { _name = value; }
      get { return _name; }
    }

    private float _price;
    public float price {
      set { _price = value; }
      get { return _price; }
    }

    public HardwareComponent(string name, float price) {
      this._name = name;
      this._price = price;
    }
  }

  class Login {
  }

  abstract class User {
    private int _permission = 0;
    private string _login;
    private string _password;
  }

  class Teacher : User {
    private int _permission = 0;
  }

  class Admin : User {
    private int _permission = 1;
  }
}
