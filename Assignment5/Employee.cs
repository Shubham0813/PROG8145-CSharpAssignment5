using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assignment5
{
    public abstract class Employee
    {
        private static int _id;
        public int ID { get; private set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int ShiftNumber { get; set; } // 1, 2 or 3 (12am-8am, 8am-4pm, 4pm-12am)
        public int Shift { get; set; } // 1 or 2 denoting Day, Night respectively

        public Employee(string name, int number, int shiftNumber, int shift)
        {
            ID = Interlocked.Increment(ref _id);
            this.Name = name;
            this.Number = number;
            this.ShiftNumber = shiftNumber;
            this.Shift = shift;
        }

        public abstract double CalculateSalary();
    }
}
