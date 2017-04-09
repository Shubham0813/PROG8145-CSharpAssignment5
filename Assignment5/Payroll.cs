using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Payroll
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public long EmployeeNumber { get; set; }
        public int ShiftNumber { get; set; }
        public int Shift { get; set; }
        public string Salary { get; set; }
        
        public Payroll()
        {

        }

        public Payroll(int ID, string employeeName, long employeeNumber, int shiftNumber, int shift, double salary)
        {
            this.ID = ID;
            this.EmployeeName = employeeName;
            this.EmployeeNumber = employeeNumber;
            this.ShiftNumber = shiftNumber;
            this.Shift = shift;
            this.Salary = "$" + salary;
        }
    }
}
