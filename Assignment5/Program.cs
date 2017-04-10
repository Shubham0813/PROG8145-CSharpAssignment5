using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    //string name, int number, int shiftNumber, double hourlyPayRate, int shift
    {
        private static Factory factory;
        static void Main(string[] args)
        {
            factory = new Factory();

            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("         ABC FACTORY          ");
                Console.WriteLine("==============================");
                Console.WriteLine("(1) Display Information");
                Console.WriteLine("(2) Update Information");
                Console.WriteLine("(3) Generate Payroll");
                Console.WriteLine("(4) Exit Software");

                choice = Utility.VerifyNumber();

                switch (choice)
                {
                    case 1:
                        ShowDisplayInformationMenu();
                        break;
                    case 2:
                        ShowUpdateInformationMenu();
                        break;
                    case 3:
                        DisplayPayroll();
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please Enter Correct Option...");
                        Console.ReadKey();
                        break;
                }
            } while (choice != 4);
            Console.ReadKey();
        }

        private static void DisplayPayroll()
        {
            List<Payroll> payrollList = factory.GeneratePayroll();

            foreach (Payroll e in payrollList)
            {
               Console.WriteLine("ID: " + e.ID);
               Console.WriteLine("Name: " + e.EmployeeName);
               Console.WriteLine("Number: " + e.EmployeeNumber);
               Console.WriteLine("Shift Number: " + e.ShiftNumber);
               Console.WriteLine("Shift: " + e.Shift);
               Console.WriteLine("Salary: " + e.Salary);
               Console.WriteLine();
            }


            Console.WriteLine("\nPayroll saved to file.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ShowDisplayInformationMenu()
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("         ABC FACTORY          ");
                Console.WriteLine("==============================");
                Console.WriteLine("(1) Display Production Workers");
                Console.WriteLine("(2) Display Shift Supervisor");
                Console.WriteLine("(3) Display Team Leaders");
                Console.WriteLine("(4) Go Back to main menu");

                choice = Utility.VerifyNumber();

                switch (choice)
                {
                    case 1:
                        factory.DisplayInformation("P"); 
                        break;
                    case 2:
                        factory.DisplayInformation("S");
                        break;
                    case 3:
                        factory.DisplayInformation("T");
                        break;
                    case 4:
                        break;
                }
            } while (choice != 4);
        }

        private static void ShowUpdateInformationMenu()
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("         ABC FACTORY          ");
                Console.WriteLine("==============================");
                Console.WriteLine("(1) Update Production");
                Console.WriteLine("(2) Update Team Leader's Training Hours");
                Console.WriteLine("(3) Go Back to main menu");

                choice = Utility.VerifyNumber();

                switch (choice)
                {
                    case 1:
                        factory.UpdateProduction();
                        break;
                    case 2:
                        factory.UpdateTrainingHours();
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            } while (choice != 3);
        }
    }
}
