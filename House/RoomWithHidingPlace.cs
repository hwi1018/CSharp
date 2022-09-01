using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class RoomWithHidingPlace : Room, IHidingPlace
    {

        public string HidingPlaceName
        {
            get;
        }

        public RoomWithHidingPlace(string name, string decoration,string hidingPlaceName) : base(name, decoration)
        {
            this.HidingPlaceName = hidingPlaceName;
        }

        public override string Description
        {
            get
            {
                return base.Description + " Someone could hide " + HidingPlaceName + ".";
            }
        }
    }
}
