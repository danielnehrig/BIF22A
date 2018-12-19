using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BKTMManager.Controller;
using BKTMManager.Types;

namespace BKTMManager.Administration {
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
}
