using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BKTMManager.Controller;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  class AdministrationManager : IOController {

    // extend the AdministrationManager Constructor from inherited class IOController
    public AdministrationManager(string ip, string db, string user, string pw):base(ip, db, user, pw) {
      // Todo
    }

    /*
     * Description - get the Device object from the given ID
     * @param <string> id - Device id from DB
     * @return Device
     */
    public Device getDeviceById(string id) {
      Device device = new Device();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Geräte] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          device.id = Convert.ToInt32(reader[0]);
          device.name = Convert.ToString(reader[1]);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      this._cnn.Close();
      return device;
    }

    /*
     * Description - get all Rooms
     * @return List<Room>
     */
    public List<Room> getAllRooms() {
      List<Room> rooms = new List<Room>();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Räume]";
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          rooms.Add(new Room(Convert.ToInt32(reader[0]), Convert.ToString(reader[1])));
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      this._cnn.Close();
      return rooms;
    }

    /*
     * Description - get the Room Name from the given ID
     * @param <string> id - room id from DB
     * @return Room
     */
    public Room getRoomById(string id) {
      Room room = new Room();
      SqlCommand command = this._cnn.CreateCommand();
      try {
        command.CommandText = "SELECT * FROM [dbo].[Räume] WHERE id LIKE " + id;
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          room.id = Convert.ToInt32(reader[0]);
          room.name = Convert.ToString(reader[1]);
        }
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      this._cnn.Close();
      return room;
    }
  }
}
