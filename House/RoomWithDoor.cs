using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    //외부로 나가는 문이 있는 방은 숨을 수 있는 방
    public class RoomWithDoor:RoomWithHidingPlace,IHasExteriorDoor
    {      
        public RoomWithDoor(string name, string deco, string doordesc,
            string hidingPlaceName):base(name, deco, hidingPlaceName)
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
