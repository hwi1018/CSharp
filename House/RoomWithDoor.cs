using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    //문을 가지고 있는 도어
    public class RoomWithDoor:Room,IHasExteriorDoor
    {
        public RoomWithDoor(string name, string deco, string doordesc):base(name, deco)
        {
            this.DoorDescription = doordesc;
        }

        public string DoorDescription
        {
            get;
        }

        public Location DoorLocation
        {
            get;set;
        }
    }
}
