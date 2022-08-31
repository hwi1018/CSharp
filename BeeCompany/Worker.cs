using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeCompany
{
    public class Worker : Bee
    {
        private string[] jobsICanDo;
        public Worker(string[] jobsICanDo, int weight) : base(weight)
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
            if (!string.IsNullOrEmpty(currentJob))
            {
                return false;
            }

            for (int i = 0; i < jobsICanDo.Length; i++)
            {
                if (jobsICanDo[i] == job)
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
}
