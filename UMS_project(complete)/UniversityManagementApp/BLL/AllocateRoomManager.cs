using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.DAL
{
    public class AllocateRoomManager
    {
        AllocateRoomGateWay allocateRoomGateWay = new AllocateRoomGateWay();
        public List<Room> GetAllRoom()
        {
            return allocateRoomGateWay.GetAllRoom();
        }

        public int Save(AllocateClassRomm allocateClassRomm)
        {
            return allocateRoomGateWay.Save(allocateClassRomm);
        }

        public bool UnallocateAllRoom()
        {
            return allocateRoomGateWay.UnallocateAllRoom();
        }
    }
}