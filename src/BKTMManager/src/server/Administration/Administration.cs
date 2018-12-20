using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BKTMManager.Controller;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  interface IAdministrationManager {
    List<HardwareComponent> GetAllHardwareComponents();
    HardwareComponent GetHardwareComponentsById(int id);
    List<Room> GetAllRooms();
    Room GetRoomById(int id);
    Room CreateRoom(string name);
    Room UpdateRoomByName(string oldName, string newName);
    List<Device> GetAllDevices();
    Device GetDeviceById(int id);
  }

  class AdministrationManager : IOController, IAdministrationManager {

    // extend the AdministrationManager Constructor from inherited class IOController
    public AdministrationManager(string ip, string db, string user, string pw):base(ip, db, user, pw) {
      // Todo
    }

    /*
     * Description - Get Component from DB by ID
     * @param int id
     * @return List<Device>
     */
    public HardwareComponent GetHardwareComponentsById(int id) {
      HardwareComponent component = new HardwareComponent();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[HardwareComponent] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
          component.id = Convert.ToInt32(reader[0]);
          component.name = Convert.ToString(reader[1]);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      return component;
    }

    /*
     * Description - Get all Componenets from DB
     * @return List<HardwareComponenet>
     */
    public List<HardwareComponent> GetAllHardwareComponents() {
      List<HardwareComponent> components = new List<HardwareComponent>();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[HardwareComponent]";
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
          components.Add(new HardwareComponent(Convert.ToInt32(reader[0]), Convert.ToString(reader[1]), Convert.ToInt32(reader[2])));
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      return components;
    }

    /*
     * Description - Get all Devices from DB
     * @return List<Device>
     */
    public List<Device> GetAllDevices() {
      List<Device> devices = new List<Device>();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Device]";
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
          devices.Add(new Device(Convert.ToInt32(reader[0]), Convert.ToString(reader[1])));
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      return devices;
    }

    /*
     * Description - get the Device object from the given ID
     * @param <string> id - Device id from DB
     * @return Device
     */
    public Device GetDeviceById(int id) {
      Device device = new Device();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Device] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          device.id = Convert.ToInt32(reader[0]);
          device.name = Convert.ToString(reader[1]);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }
      this._cnn.Close();
      return device;
    }

    /*
     * Description - Create a New Room
     * @return - Room
     */
    public Room CreateRoom(string name) {
      Room room = new Room();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "INSERT INTO [dbo].[Room] (name) VALUES (" + name + ")";
        SqlDataReader reader = command.ExecuteReader();
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      this._cnn.Close();
      return room;
    }

    /*
     * Description - Update a New Room
     * @param string oldName
     * @param string newName
     * @return - Room
     */
    public Room UpdateRoomByName(string oldName, string newName) {
      Room room = new Room();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "UPDATE [dbo].[Room] SET name = '" + newName + "' WHERE name = '" + oldName + "'";
        SqlDataReader reader = command.ExecuteReader();
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      this._cnn.Close();
      return room;
    }

    /*
     * Description - get all Rooms
     * @return List<Room>
     */
    public List<Room> GetAllRooms() {
      List<Room> rooms = new List<Room>();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Room]";
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          rooms.Add(new Room(Convert.ToInt32(reader[0]), Convert.ToString(reader[1])));
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      this._cnn.Close();
      return rooms;
    }

    /*
     * Description - get the Room Name from the given ID
     * @param <string> id - room id from DB
     * @return Room
     */
    public Room GetRoomById(int id) {
      Room room = new Room();
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Room] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          room.id = Convert.ToInt32(reader[0]);
          room.name = Convert.ToString(reader[1]);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      this._cnn.Close();
      return room;
    }
  }
}
