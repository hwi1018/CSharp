using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class Room : Location
    {
        public Room(string name, string decoration):base(name)
        {
            this.Decoration = decoration;
        }

        public string Decoration
        {
            get;set;
        }

        //부모클래스에 Virtual 때문에 override로 자식 클래스에서 함수를 구현해야 한다.
        public override string Description
        {
            get
            {
                return base.Description + " You See " + Decoration + ".";
            }
        }
    }
}
