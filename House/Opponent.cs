using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    //술래
    public class Opponent
    {
        private Random random;
        private Location myLocation;

        public Opponent(Location startLocation)
        {
            myLocation = startLocation;
            random = new Random();
        }

        public void Move()
        {
            if(myLocation is IHasExteriorDoor)
            {
                IHasExteriorDoor LocationWithDoor = myLocation as IHasExteriorDoor;
                
                //50% 확률
                if(random.Next(2) == 1)
                {
                    myLocation = LocationWithDoor.DoorLocation;
                }
            }
            bool hidden = false;
            while(!hidden)
            {
                int rand = random.Next(myLocation.Exits.Length);
                myLocation = myLocation.Exits[rand];
                //숨을 장소(문이 있는 장소)이면 숨는다
                if(myLocation is IHidingPlace)
                {
                    hidden = true;
                }
            }
        }

        //숨어있는 사람이 있는 지 체크
        public bool Check(Location locationToCheck)
        {
            if(locationToCheck != myLocation)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
