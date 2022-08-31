using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCompany
{
    public class Queen : Bee
    {
        //일벌 
        private Worker[] workers;
        public Queen(Worker[] workers) : base(275)
        {
            this.workers = workers;
        }

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DoThisJob(job, numberOfShifts))
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
            for (int i = 0; i < workers.Length; i++)
            {
                totalConsumption += workers[i].GetHoneyComsumption();
            }
            totalConsumption += GetHoneyComsumption();

            shiftNumber++;
            string report = "";
            StringBuilder sb = new StringBuilder();
            report = "Report for shift #" + shiftNumber + "\r\n";
            sb.Append(report);
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].WorkOneShift())
                {
                    report = string.Format("Worker #{0}, finished the job\r\n", i + 1);
                    sb.Append(report);
                }
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                {
                    report = string.Format("Worker #{0}, is not working\r\n", i + 1);
                    sb.Append(report);
                }
                else
                {
                    if (workers[i].ShiftLeft > 0)
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

            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].GetHoneyComsumption() > largestWorkerConsumption)
                {
                    largestWorkerConsumption = workers[i].GetHoneyComsumption();
                }
                if (workers[i].ShiftLeft > 0)
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
