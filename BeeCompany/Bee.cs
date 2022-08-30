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

    public class Worker:Bee
    {
        private string[] jobsICanDo;
        public Worker(string[] jobsICanDo, int weight):base(weight)
        {
            this.jobsICanDo = jobsICanDo;
        }

        private int shiftsToWork;
        private int shiftsWorked;
        public override int ShiftLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }

        private string currentJob = "";
        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }

        public bool DoThisJob(string job, int numberOfShifts)
        {
            if(!string.IsNullOrEmpty(currentJob))
            {
                return false;
            }

            for(int i =0;i<jobsICanDo.Length;i++)
            {
                if(jobsICanDo[i] == job)
                {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    shiftsWorked = 0;
                    return true;
                }
            }

            return false;
        }

        public bool WorkOneShift()
        {
            if (string.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;
            }
            else
                return false;
        }


       
    }

    public class Queen:Bee
    {
        private Worker[] workers;
        public Queen(Worker[] workers):base(275)
        {
            this.workers = workers;
        }
        
        public bool AssignWork(string job, int numberOfShifts)
        {
            for(int i =0;i<workers.Length;i++)
            {
                if(workers[i].DoThisJob(job, numberOfShifts))
                {
                    return true;
                }
            }
            return false;
        }

        private int shiftNumber = 0;
        public string WorkTheNextShift()
        {
            double totalConsumption = 0;
            for(int i=0;i<workers.Length;i++)
            {
                totalConsumption += workers[i].GetHoneyComsumption();
            }
            totalConsumption += GetHoneyComsumption();

            shiftNumber++;
            string report = "";
            StringBuilder sb = new StringBuilder();
            report = "Report for shift #" + shiftNumber + "\r\n";
            sb.Append(report);
            for(int i =0; i<workers.Length;i++)
            {
                if(workers[i].WorkOneShift())
                {
                    report = string.Format("Worker #{0}, finished the job\r\n", i + 1);
                    sb.Append(report);
                }
                if(String.IsNullOrEmpty(workers[i].CurrentJob))
                {
                    report = string.Format("Worker #{0}, is not working\r\n", i + 1);
                    sb.Append(report);
                }
                else
                {
                    if(workers[i].ShiftLeft >0)
                    {
                        report = string.Format("Worker #{0} is doing {1} for {2} more shifts\r\n",
                            i + 1, workers[i].CurrentJob, workers[i].ShiftLeft);
                        sb.Append(report);
                    }
                    else
                    {
                        report = string.Format("Worker #{0} will be done with {1} after this shifts\r\n",
                            i + 1, workers[i].CurrentJob);
                        sb.Append(report);
                    }
                }
            }

            report = string.Format("Total Honey Consumption: {0} units\r\n", totalConsumption);
            sb.Append(report);

            return sb.ToString();
        }

        public override double GetHoneyComsumption()
        {
            double consumption = 0.0;
            double largestWorkerConsumption = 0;
            int workersDoingJobs = 0;

            for(int i =0;i<workers.Length;i++)
            {
                if(workers[i].GetHoneyComsumption()>largestWorkerConsumption)
                {
                    largestWorkerConsumption = workers[i].GetHoneyComsumption();
                }
                if(workers[i].ShiftLeft>0)
                {
                    workersDoingJobs++;
                }
            }
            consumption += largestWorkerConsumption;
            if (workersDoingJobs >= 3)
                consumption += 30;
            else
                consumption += 20;

            return consumption;
        }
    }

}


