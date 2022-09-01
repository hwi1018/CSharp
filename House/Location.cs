using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    //뼈대만 제공
    public abstract class Location
    {
        protected Location(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public Location[] Exits { get; set; }

        //Virtual 선언을 통해 상속받는 자식 클래스에서 서로 내용을 다르게 구현
        public virtual string Description
        {
            get
            {
                string desc = "You're standing in the " + Name + ". You See exits to the following places: ";

                for (int i=0;i<Exits.Length;i++)
                {
                    if (i != Exits.Length-1)
                    {
                        desc += ".";
                    }
                }
                desc += ".";
                return desc;

            }
        }
    }
}
