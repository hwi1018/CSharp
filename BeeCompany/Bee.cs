using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCompany
{
    //벌의 역할
    public class Bee
    {
        private double weight = 0.0;
        public Bee(double weight)
        {
            this.weight = weight;
        }
        
        //시간당 벌들의 일
        public virtual int ShiftLeft
        {
            get { return 0; }
        }

        public virtual double GetHoneyComsumption()
        {
            double consumption;
            if (ShiftLeft == 0)
                consumption = 7.5;
            else
                consumption = 9 + ShiftLeft;

            if (weight > 150)
                consumption *= 1.35;

            return consumption;
        }
    }

}


