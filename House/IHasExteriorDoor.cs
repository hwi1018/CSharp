using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    //외부로 나가는 문이 있는지
    public interface IHasExteriorDoor
    {
        string DoorDescription { get; }
        Location DoorLocation { get; set; }
    }
}
