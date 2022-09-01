using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class OutSideWithHidingPlace : OutSide, IHidingPlace
    {
        public string HidingPlaceName
        {
            get;
        }
        
        public OutSideWithHidingPlace(string name, bool hot, string hidingPlaceName) :
            base(name, hot)
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
