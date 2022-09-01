using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    //문이있는 방은 무조건 숨을 수 있는 곳
    public class OutSideWithDoor:OutSideWithHidingPlace, IHasExteriorDoor
    {
        public OutSideWithDoor(string name, bool hot, string doordesc, string hidingPlaceName):base(name, hot, hidingPlaceName)
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

        public override string Description
        {
            get
            {
                return base.Description + " You See " + DoorDescription + ".";
            }
        }


    }
}
