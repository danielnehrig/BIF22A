using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Damaged : TypeRepo {
    public Damaged() { }

    public Damaged(SqlDataReader reader) {
      this._id = reader.GetInt32(reader.GetOrdinal("da_id"));
      this._date = reader.GetDateTime(reader.GetOrdinal("date"));
      this._description = reader.GetString(reader.GetOrdinal("description"));
      this._deviceId = reader.GetInt32(reader.GetOrdinal("deviceId"));
      this.tableNormal = String.Format(@"ID -- DATE -- DESCRIPTION --: DEVICEID
{0}   {1}     {2}          {3}
", this.id, this.date, this.description, this.deviceId);
    }

    public Damaged(SqlDataReader reader, Device device, Teacher teacher) {
      this._id = reader.GetInt32(reader.GetOrdinal("da_id"));
      this._date = reader.GetDateTime(reader.GetOrdinal("date"));
      this._description = reader.GetString(reader.GetOrdinal("description"));
      this._deviceId = reader.GetInt32(reader.GetOrdinal("deviceId"));
      this._device = device;
      this._teacher = teacher;
      this.tablePopulated = String.Format(@"ID -- DATE -- DESCRIPTION --: DEVICE :-- PRICE --:-- DATE --:-- CATEGORY --:-- RESELLER --:-- LOCATION --
{0}   {1}     {2}        {3}     {4}     {5}    {6}    {7}
", this.id, this.date, this.description, this.device.price, this.device.dateBuy, this.device.category.name, this.device.reseller.name, this.device.reseller.location);
    }


    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private Device _device;
    public Device device {
      get { return _device; }
      set { _device = value; }
    }

    private Teacher _teacher;
    public Teacher teacher {
      get { return _teacher; }
      set { _teacher = value; }
    }

    private DateTime _date;
    public DateTime date {
      get { return _date; }
      set { _date = value; }
    }
    private string _description;
    public string description {
      get { return _description; }
      set { _description = value; }
    }

    private int _deviceId;
    public int deviceId {
      get { return _deviceId; }
      set { _deviceId = value; }
    }

    private int _teacherId;
    public int teacherId {
      get { return _teacherId; }
      set { _teacherId = value; }
    }
  }
}
