using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceTest_IClown
{
    public class FunnyFunny : IClown
    {
        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }

        //IClown의 내용을 구현
        private string funnyThingIHave;
        public string FunnyThingIHave
        {
            get { return "Honk honk! I have " + funnyThingIHave; }
        }

        public void Honk()
        {
            MessageBox.Show(this.FunnyThingIHave);
        }
       
    }
}
