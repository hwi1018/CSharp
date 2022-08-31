using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceTest_IClown
{
    public class ScaryScary:FunnyFunny,IScaryClown
    {
        //ScaryScary는 FunnyFunny를 상속받기 때문에 IClown도 상속받게 됨

        public ScaryScary(string funnyThingIHave, int numberOfScaryThings):base(funnyThingIHave)
        {
            this.numberOfScaryThings = numberOfScaryThings;
        }

        private int numberOfScaryThings;
        public string ScaryThingIHave
        {
            get { return "I have " + numberOfScaryThings + " spiders"; }
        }

        public void ScaryLittleChildren()
        {
            MessageBox.Show("Boo! Gotcha");
        }

    }
}
