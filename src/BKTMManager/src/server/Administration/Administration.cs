using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BKTMManager.Controller;
using BKTMManager.Types;
using System.Globalization;
using System.Data.Entity;

/**
 * What is my Problem with this Code? :
 *
 * I have one problem with this
 * I don't want to generate redundant code
 * means that my class composition and aggragation
 * should act in a way that it helps me to not get in a habit of duplicating code functions that basically do the same with minor differences
 * for example i want to make a CREATE,UPDATE,DELETE,GET (CRUD) function for a certain item from a database
 * the probleme is that the different tables i want this schema to apply
 * are in different object types one might be a Room the other one a Device but i want all these functions to apply to both objects
 */

/**
 * How can i solve the Problem?
 *
 * Using the administrationmanager and create a composition between various types means
 * i would do something like 
 * AdministrationManager().Device.Create();
 * AdministrationManager().Room.Update();
 * mean the user would interact with the administrationmanager backend
 * i would create a interface for the functions i want in my derivated database types like Device and Room
 */

/**
 * Solution :
 * The RepoAdmin.cs
 * should solve the problem with a Generic Repository design pattern
 */

namespace BKTMManager.Administration {
  interface IAdministrationManager {
    List<HardwareComponent> GetAllHardwareComponents();
    HardwareComponent GetHardwareComponentsById(int id);
    void CreateHardwareComponent(int id, string name, float price, bool isExchanged, string description);
    void UpdateHardwareComponentById(int id, string name);
    void DeleteHardwareComponentById(int id);
    List<Room> GetAllRooms();
    Room GetRoomById(int id);
    void CreateRoom(string name);
    void DeleteRoom(string name);
    void UpdateRoomByName(string oldName, string newName);
    List<Device> GetAllDevices();
    Device GetDeviceById(int id);
    void DeleteDevice(int id);
  }

  class AdministrationManager : IOController {
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
        command.CommandText = "SELECT * FROM [dbo].[HardwareComponent] WHERE id LIKE @id";
        command.Parameters.AddWithValue("@id", id);
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read()) {
          component.id = reader.GetInt32(0);
          component.name = reader.GetString(1);
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
          HardwareComponent temp = new HardwareComponent();
          temp.id = reader.GetInt32(0);
          temp.name = reader.GetString(1);
          temp.price = reader.GetFloat(2);
          temp.isExchanged = reader.GetByte(3);
          temp.description = reader.GetString(4);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }

      return components;
    }

    /*
     * Description - Create Component
     * @return HardwareComponenet
     */
    public void CreateHardwareComponent(string name, float price, bool isExchanged, string description) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = String.Format("INSERT INTO [dbo].[HardwareComponent] (name, price, isExchanged, description) VALUES (@name, @price, @isExchanged, @description)");
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@price", price);
        command.Parameters.AddWithValue("@isExchanged", isExchanged);
        command.Parameters.AddWithValue("@description", description);
        command.ExecuteNonQuery();
        this.closeConnection();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }

    /*
     * Description - Update Component
     */
    public void UpdateHardwareComponentById(int id, string name) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = String.Format("UPDATE [dbo].[HardwareComponent] SET name = @name WHERE id = @id");
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", name);
        command.ExecuteNonQuery();
        this.closeConnection();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }

    /*
     * Description - Delete Component
     */
    public void DeleteHardwareComponentById(int id) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = String.Format("DELETE FROM [dbo].[HardwareComponent] WHERE id = @id");
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        this.closeConnection();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
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
          devices.Add(new Device(reader.GetInt32(0), reader.GetString(1)));
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
        command.CommandText = "SELECT * FROM [dbo].[Device] WHERE id LIKE @id";
        command.Parameters.AddWithValue("@id", id);
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          device.id = reader.GetInt32(0);
          device.name = reader.GetString(1);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return null;
      }
      this._cnn.Close();
      return device;
    }

    /*
     * Description - Delete a Room
     */
    public void DeleteDevice(string id) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "DELETE FROM [dbo].[Device] WHERE id = @id";
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }

      this._cnn.Close();
    }

    /*
     * Description - Create a New Room
     */
    public void CreateRoom(string name, string description) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "INSERT INTO [dbo].[Room] (roomNr, description) VALUES (@name, @description)";
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@description", description);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }

      this._cnn.Close();
    }

    /*
     * Description - Delete a Room
     */
    public void DeleteRoom(string name) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "DELETE FROM [dbo].[Room] WHERE roomNr = @name";
        command.Parameters.AddWithValue("@name", name);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }

      this._cnn.Close();
    }

    /*
     * Description - Update a New Room
     * @param string oldName
     * @param string newName
     */
    public void UpdateRoomByName(string oldName, string newName) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "UPDATE [dbo].[Room] SET roomNr = @newName WHERE roomNr = @oldName";

        command.Parameters.AddWithValue("@oldName", oldName);
        command.Parameters.AddWithValue("@newName", newName);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }

      this._cnn.Close();
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
          rooms.Add(new Room(reader.GetInt32(0), reader.GetString(1)));
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
    public void GetRoomById(int id) {
      this.openConnection();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Room] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          Console.WriteLine(Convert.ToInt32(reader[0]));
          Console.WriteLine(Convert.ToString(reader[1]));
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }

      this._cnn.Close();
    }
  }
}
