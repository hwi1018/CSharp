using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class OutSide: Location
    {
        public bool Hot { get; }

        public OutSide(string name, bool hot):base(name)
        {
            this.Hot = hot;
        }

        //부모클래스에 Virtual 때문에 override로 자식 클래스에서 함수를 구현해야 한다.
        public override string Description
        {
            get
            {
                string newDesc = base.Description;
                if (this.Hot)
                    newDesc += "It's very Hot";

                return newDesc;
            }
        }
    }
}
