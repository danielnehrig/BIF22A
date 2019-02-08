using System;
using System.Collections.Generic;
using BKTMManager.Helper;
using BKTMManager.Administration;
using BKTMManager.Controller;

namespace BKTMManager.Administration {
  public class Manager : IOController {
    public DeviceAdministration device;
    public RoomAdministration room;
    public UserAdministration user;
    public CategoryAdministration category;
    public HardwareAdministration hardware;

    public Manager(Dictionary<string, string> cnnInfo):base(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]) {
      device = new DeviceAdministration(this._cnn);
      room = new RoomAdministration(this._cnn);
      user = new UserAdministration(this._cnn);
      hardware = new HardwareAdministration(this._cnn);
      category = new CategoryAdministration(this._cnn);
    }
  }
}
