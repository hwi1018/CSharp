using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCompany
{
    public class NectarStinger: Worker, IStingPatrol, INectarCollector
    {
        //인터페이스를 가져왔으니 속성, 메소드를 구현해야함
        private int alertLevel;
        public int AlertLevel
        {
            get { return alertLevel; }
        }

        private int stingerLength;

        public NectarStinger(string[] jobsICanDo, int weight) : base(jobsICanDo, weight)
        {
        }

        public int StingerLength
        {
            get { return stingerLength; }
            set
            {
                stingerLength = value;
            }
        }
       

        public bool LookForEnemies()
        {
            return false;
        }

        public int SharpenStinger(int Length)
        {
            return 0;
        }

        public void FindFlowers()
        {

        }

        public void GatherNectar()
        {

        }

        public void ReturnToHive()
        {

        }

    }
}
