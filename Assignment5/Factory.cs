using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Factory
    {
        public static List<Employee> Employees;

        public static int[] ProductionGoals = {1200,2400,3600};

        public Factory()
        {
            Employees = new List<Employee>();

            CreateWorkers();
            CreateSupervisor();
            CreateTeamLeaders();
        }

        private void CreateWorkers()
        {
            ProductionWorker productionWorker1 = new ProductionWorker("John", 1111, 1, 11.65, 2);
            ProductionWorker productionWorker2 = new ProductionWorker("Dwayne", 1111, 2, 11.65, 2);
            ProductionWorker productionWorker3 = new ProductionWorker("Saitama", 1111, 3, 11.65, 1); 

            Employees.AddRange(new List<Employee> { productionWorker1, productionWorker2, productionWorker3 } );
        }

        private void CreateSupervisor()
        {
            ShiftSupervisor shiftSupervisor = new ShiftSupervisor("Burak", 1112, 1, 2, 20000);
            Employees.Add(shiftSupervisor);
        }

        private void CreateTeamLeaders()
        {
            TeamLeader teamLeader1 = new TeamLeader("Amrit", 12, 1, 20.65, 1, 32);
            TeamLeader teamLeader2 = new TeamLeader("Joel", 13, 2, 20.65, 2, 32);
            Employees.AddRange(new List<Employee> { teamLeader1, teamLeader2 });
        }

        internal void DisplayInformation(string v)
        {
            Console.Clear();
            switch(v.ToUpper())
            {
                case "P":
                    var productionWorkers = Employees.Where(e => e.GetType() == typeof(ProductionWorker));
                    DisplayProductionWorkers(productionWorkers);
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                    break;
                case "S":
                    var shiftSupervisor = from s in Employees
                                            where s is ShiftSupervisor
                                            select s;
                    DisplayShiftSupervisor(shiftSupervisor);
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                    break;
                case "T":
                    var teamLeaders = from t in Employees
                                            where t is TeamLeader
                                            select t;
                    DisplayTeamLeaders(teamLeaders);
                    Console.WriteLine("\nPress any key to go back...");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }

        internal void DisplayProductionWorkers(IEnumerable<Employee> productionWorkers)
        {
            foreach(ProductionWorker p in productionWorkers)
            {
                Console.WriteLine("\nID: " + p.ID + "," + " Name: " + p.Name + ", " + " Number: " + p.Number);
                Console.WriteLine("Shift Number: " + p.ShiftNumber + ", " + "Shift: " + p.Shift);
                Console.WriteLine("Hourly Pay Rate: $" + p.HourlyPayRate);
            }
        }

        private void DisplayShiftSupervisor(IEnumerable<Employee> shiftSupervisor)
        {
            foreach (ShiftSupervisor s in shiftSupervisor)
            {
                Console.WriteLine("\nID: " + s.ID + ", " + " Name: " + s.Name + ", " + " Number: " + s.Number);
                Console.WriteLine("Shift Number: " + s.ShiftNumber + ", " + " Shift: " + s.Shift);
                Console.WriteLine("Yearly Salary: $" + s.YearlySalary + ", " + "Shift Bonus: $" + s.ShiftBonus);
            }
        }

        internal void DisplayTeamLeaders(IEnumerable<Employee> teamLeaders)
        {
            foreach (TeamLeader t in teamLeaders)
            {
                Console.WriteLine("\nID: " + t.ID + "," + " Name: " + t.Name + ", " + " Number: " + t.Number);
                Console.WriteLine("Shift Number: " + t.ShiftNumber + "," + " Shift: " + t.Shift);
                Console.WriteLine("Traning Hours Required: " + t.TrainingHoursRequired + ", " + "Traning Hours Completed: " + t.TrainingHoursCompleted);
                Console.WriteLine("Hourly Pay Rate: $" + t.HourlyPayRate);
                Console.WriteLine("Monthly Bonus: $" + t.MONTHLY_BONUS_AMOUNT);
            }
        }

        internal void UpdateTrainingHours()
        {
            TeamLeader teamLeader = null;

            foreach(Employee e in Employees.Where(e => e is TeamLeader))
            {
                Console.WriteLine("\n" + e.ID + ", " + e.Name);
            }

            bool valid = false;

            Console.WriteLine("here");

            do {
                Console.WriteLine("\n\nEnter the ID of Team Leader to update Training Hours: ");
                int input = Utility.VerifyNumber();

                try
                {
                    var employee = Employees.Find(e => e.ID == input);
                    if(employee is TeamLeader)
                    {
                        teamLeader = (TeamLeader) employee;
                        valid = true;
                    }
                } catch(Exception e)
                {
                    Console.WriteLine(e.GetBaseException());
                    Console.WriteLine("\nEmployee with this ID not found. Try Again...");
                }
            } while (!valid);

            if(teamLeader.TrainingHoursCompleted >= teamLeader.TrainingHoursRequired)
            {
                Console.WriteLine("\nThis person has already completed required training hours. Press any key to go back...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nEnter hours of training completed: ");
            teamLeader.TrainingHoursCompleted = Utility.VerifyNumber();

            Console.WriteLine("\nInformation Updated Successfully. \nPress any key to continue...");
            Console.ReadKey();
            return;
    }

        internal void UpdateProduction()
        {
            int shiftNumber = 0;
            do
            {
                Console.WriteLine("\nEnter the shift number to update production for (1, 2 or 3): ");
                shiftNumber = Utility.VerifyNumber();
            } while((shiftNumber < 1) && (shiftNumber > 3));

            Console.WriteLine("Enter production: ");
            int production = Utility.VerifyNumber();

            ShiftSupervisor supervisor = (ShiftSupervisor) Employees.Find(e => e is ShiftSupervisor);

            if (supervisor.ShiftNumber == shiftNumber)
            {
                supervisor.addShiftBonus(production);
            }

            Console.WriteLine("\nInformation Updated Successfully. \nPress any key to continue...");
            Console.ReadKey();
        }

        internal void GeneratePayroll()
        {
            Console.Clear();

            foreach (Employee employee in Employees)
            {
                int ID = employee.ID;
                string employeeName = employee.Name;
                long employeeNumber = employee.Number;
                int shiftNumber = employee.ShiftNumber;
                int shift = employee.Shift;
                double salary = employee.CalculateSalary();

                Payroll payroll = new Payroll(ID, employeeName, employeeNumber, shiftNumber, shift, salary);
                Utility.WriteToJsonFile(@"Payroll.json", payroll);

                Console.WriteLine("ID: " + ID);
                Console.WriteLine("Name: " + employeeName);
                Console.WriteLine("Number: " + employeeNumber);
                Console.WriteLine("Shift Number: " + shiftNumber);
                Console.WriteLine("Shift: " + shift);
                Console.WriteLine("Salary: $" + salary);
                Console.WriteLine();
            }

            Console.WriteLine("\nPayroll saved to file.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }


    }
}
