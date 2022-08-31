using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using InterfaceTest_IClown;

namespace HeadFirst
{
    /// <summary>
    /// ClownTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClownTest : Window
    {
        public ClownTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScaryScary fingersTheClown = new ScaryScary("big shoes", 14);

            FunnyFunny someFunnyClown = fingersTheClown;//ScaryScary는 FunnyFunny를 상속받았기 때문에 가능하다.

            IScaryClown someOtherScaryClown = someFunnyClown as ScaryScary; //ScaryScary로 다운캐스팅 한거임

            someOtherScaryClown.Honk(); //무서운 광대의 Honk호출
            
        }
    }
}
