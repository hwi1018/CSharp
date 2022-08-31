using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class OutSideWithDoor:OutSide, IHasExteriorDoor
    {
        public OutSideWithDoor(string name, bool hot, string doordesc):base(name, hot)
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
