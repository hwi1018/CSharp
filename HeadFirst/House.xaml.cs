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
using House;

namespace HeadFirst
{
    /// <summary>
    /// House.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class House : Window
    {
        Location currentLocation; //객체가 아닌 참조변수

        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;

        OutSideWithDoor frontYard;
        OutSideWithDoor backYard;
        OutSide garden;

        public House()
        {
            InitializeComponent();

            CreateObjects();

            MoveToNewLocation(livingRoom);
        }

        private void CreateObjects()
        {
            
            livingRoom = new RoomWithDoor("living Room", "carpet", "oak door", "X");
            diningRoom = new Room("dining Room", "crystal chandelier");
            kitchen = new RoomWithDoor("kitchen", "steel appliances", "screen door", "X");

            frontYard = new OutSideWithDoor("front Yard", false, "oak door","X");
            backYard = new OutSideWithDoor("back Yard", true, "screen door", "X");
            garden = new OutSide("garden", false);

            //부모의 참조변수로 자식클래스의 객체를 접근할 수 있음
            //Roow, OutSide, RoomWithDoor, OutSideWithDoor는 모두 Location을 상속 받음
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom };
            kitchen.Exits = new Location[] { diningRoom };

            frontYard.Exits = new Location[] {backYard, garden };
            backYard.Exits = new Location[] { frontYard, garden };
            garden.Exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void MoveToNewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            cmbExits.Items.Clear();
            for(int i =0;i<currentLocation.Exits.Length;i++)
            {
                cmbExits.Items.Add(currentLocation.Exits[i].Name);
            }
            cmbExits.SelectedIndex = 0;

            txtDescription.Text = currentLocation.Description;

            if(currentLocation is IHasExteriorDoor)
            {
                btnGoThroughTheDoor.Visibility = Visibility.Visible;
            }
            else
            {
                btnGoThroughTheDoor.Visibility = Visibility.Hidden;
            }
        }

        private void BtnGoHere_Click(object sender, RoutedEventArgs e)
        {
            MoveToNewLocation(currentLocation.Exits[cmbExits.SelectedIndex]); //선택한 인덱스로 이동
        }

        private void BtnGoThroughTheDoor_Click(object sender, RoutedEventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToNewLocation(hasDoor.DoorLocation); //hasDoor에서 인터페이스를 통해 Location으로 접근
        }
    }
}
