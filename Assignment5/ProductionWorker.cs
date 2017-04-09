using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class ProductionWorker : Employee
    {
        public double HourlyPayRate { get; set; }
        
        public ProductionWorker(string name, int number, int shiftNumber, double hourlyPayRate, int shift) : base(name, number,shiftNumber, shift)
        {
            this.HourlyPayRate = hourlyPayRate;
        }

        public override double CalculateSalary()
        {
            double salary = (HourlyPayRate * 8);

            if(this.Shift == 2)
            {
                salary = salary * 1.5;
            }

            return (salary - Utility.CalculateTax(salary));
        }
    }
}
