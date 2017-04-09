using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class ShiftSupervisor : Employee
    {
        public double YearlySalary { get; set; }

        /* The amount of shift bonus is dependent on the whether his or her shift meets the production output goals specified by the company. */
        public int ShiftBonus { get; set; }

        public ShiftSupervisor(string name, int number, int shiftNumber, int shift, double yearlySalary) : base(name, number, shiftNumber, shift)
        {
            this.YearlySalary = yearlySalary;
            ShiftBonus = 0;
        }

        public void addShiftBonus(int production)
        {
            if(production >= Factory.ProductionGoals[0] && production < Factory.ProductionGoals[1])
            {
                ShiftBonus = 500;
            } else if (production >= Factory.ProductionGoals[1] && production < Factory.ProductionGoals[2])
            {
                ShiftBonus = 1000;
            } else if (production >= Factory.ProductionGoals[2])
            {
                ShiftBonus = 1500;
            } else
            {
                ShiftBonus = 0;
            }
        }

        public override double CalculateSalary()
        {
            double salary =  (YearlySalary + ShiftBonus);
            if(Shift == 2)
            {
                salary = salary * 1.5;
            }
            return (salary - Utility.CalculateTax(salary));
        }
    }
}