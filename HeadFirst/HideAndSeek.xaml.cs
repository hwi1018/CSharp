using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// HideAndSeek.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HideAndSeek : Window
    {
        int Moves = 0; //움직임
        Location currentLocation; //객체가 아닌 참조변수

        RoomWithDoor livingRoom;
        RoomWithHidingPlace diningRoom;
        RoomWithDoor kitchen;
        Room stairs;
        RoomWithHidingPlace halllway;
        RoomWithHidingPlace bathroom;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;

        OutSideWithDoor frontYard;
        OutSideWithDoor backYard;
        OutSideWithHidingPlace garden;
        OutSideWithHidingPlace driveway;

        Opponent opponent;

        public HideAndSeek()
        {
            InitializeComponent();

            CreateObjects();

            opponent = new Opponent(frontYard);

            ResetGame(false);
        }
        private void CreateObjects()
        {

            livingRoom = new RoomWithDoor("living Room", "carpet", "옷장", "oak door");
            diningRoom = new RoomWithHidingPlace("dining Room", "crystal chandelier", "조각상");
            kitchen = new RoomWithDoor("kitchen", "steel appliances","벽장", "screen door");
            stairs = new Room("stairs", "a wooden bannister");
            halllway = new RoomWithHidingPlace("hallway", "a picture of dog", "벽장");
            bathroom = new RoomWithHidingPlace("bathroom", "a sink of toilet", "샤워장");
            masterBedroom = new RoomWithHidingPlace("masterBedroom", "a large bed", "침대 밑");
            secondBedroom = new RoomWithHidingPlace("secondBedroom", "a small bed", "침대 밑");

            frontYard = new OutSideWithDoor("front Yard", false, "oak door", "문틈");
            backYard = new OutSideWithDoor("back Yard", true, "screen door", "문틈");
            garden = new OutSideWithHidingPlace("garden", false, "잔디");
            driveway = new OutSideWithHidingPlace("driveway", false, "창고");
           
            //부모의 참조변수로 자식클래스의 객체를 접근할 수 있음
            //Roow, OutSide, RoomWithDoor, OutSideWithDoor는 모두 Location을 상속 받음
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom,stairs };
            kitchen.Exits = new Location[] { diningRoom };
            stairs.Exits = new Location[] { livingRoom, halllway };
            halllway.Exits = new Location[] { stairs, bathroom, masterBedroom, secondBedroom };
            bathroom.Exits = new Location[] { halllway };
            masterBedroom.Exits = new Location[] { halllway};
            secondBedroom.Exits = new Location[] { halllway};

            frontYard.Exits = new Location[] { backYard, garden, driveway };
            backYard.Exits = new Location[] { frontYard, garden, driveway };
            garden.Exits = new Location[] { frontYard, backYard };
            driveway.Exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }
        private void MoveToNewLocation(Location newLocation)
        {
            Moves++; //움직일 때 마다 Moves 증가
            currentLocation = newLocation;
            RedrawForm();
         
        }
        private void RedrawForm()
        {
            cmbExits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {
                cmbExits.Items.Add(currentLocation.Exits[i].Name);
            }
            cmbExits.SelectedIndex = 0;

            txtDescription.Text = currentLocation.Description + "\r\n(move #" + Moves + ")";

            if (currentLocation is IHidingPlace)
            {
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;

                btnCheck.Content = "Check " + hidingPlace.HidingPlaceName;
                btnCheck.Visibility = Visibility.Visible;
            }
            else
            {
                btnCheck.Visibility = Visibility.Hidden;
            }

            if(currentLocation is IHasExteriorDoor)
            {
                btnGoThroughTheDoor.Visibility = Visibility.Visible;
            }
            else
            {
                btnGoThroughTheDoor.Visibility = Visibility.Hidden;
            }
        }

        private void ResetGame(bool IsDisplayMessage)
        {
            if(IsDisplayMessage)
            {
                MessageBox.Show("You found me in " + Moves + " moves!");
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;
                txtDescription.Text = "You found your opponent in " + Moves +
                    " moves! He was hiding " + hidingPlace.HidingPlaceName + ".";
            }
            Moves = 0;
            btnHide.Visibility = Visibility.Visible;
            btnGoHere.Visibility = Visibility.Hidden;
            btnCheck.Visibility = Visibility.Hidden;
            btnGoThroughTheDoor.Visibility = Visibility.Hidden;
            cmbExits.Visibility = Visibility.Hidden;

        }
        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            Moves++;
            if(opponent.Check(currentLocation))
            {
                ResetGame(true);
            }
            else
            {
                RedrawForm();
            }
        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            btnHide.Visibility = Visibility.Hidden;

            for (int i = 0; i < 10; i++)
            {
                opponent.Move();
                txtDescription.Text = i + "... ";
                UpdateLayout();

                Thread.Sleep(200);
            }
            txtDescription.Text = "Ready or Not, here I come!";
            UpdateLayout();
            Thread.Sleep(500);

            btnGoHere.Visibility = Visibility.Visible;
            cmbExits.Visibility = Visibility.Visible;
            MoveToNewLocation(livingRoom);
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
