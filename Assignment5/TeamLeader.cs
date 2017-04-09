using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class TeamLeader : ProductionWorker
    {
        public double MONTHLY_BONUS_AMOUNT = 1500.65;
        public int TrainingHoursRequired { get; set; }
        public int TrainingHoursCompleted { get; set; }

        public TeamLeader(string name, int number, int shiftNumber, double hourlyPayRate, int shift
            , int trainingHoursRequired) : base(name, number, shiftNumber, hourlyPayRate, shift)
        {
            this.TrainingHoursRequired = trainingHoursRequired;
        }

        public override double CalculateSalary()
        {
            //double salary = base.CalculateSalary();

            double salary = (HourlyPayRate * 8);

            if (this.Shift == 2)
            {
                salary = salary * 1.5;
            }

            salary += MONTHLY_BONUS_AMOUNT;

            return (salary - Utility.CalculateTax(salary));
        }
    }
}
