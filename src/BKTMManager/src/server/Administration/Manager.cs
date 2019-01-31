using System;
using System.Collections.Generic;
using BKTMManager.Helper;
using BKTMManager.Administration;

namespace BKTMManager.Administration {
  public class Manager {
    public DeviceAdministration device;
    public RoomAdministration room;
    public UserAdministration user;
    public HardwareAdministration hardware;

    public Manager(Dictionary<string, string> cnnInfo) {
      device = new DeviceAdministration(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);
      room = new RoomAdministration(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);
      user = new UserAdministration(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);
      hardware = new HardwareAdministration(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]);
    }
  }
}
