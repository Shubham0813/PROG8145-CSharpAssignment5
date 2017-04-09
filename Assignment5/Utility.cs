using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Utility
    {
        private static double TAX_PERCENTAGE = 13;

        public static int VerifyNumber()
        {
            int num;
            bool valid = false;
            do
            {
                if (!Int32.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Please enter correct option");
                }
                else
                {
                    valid = true;
                }
            } while (!valid);

            return num;
        }


        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            catch
            {
                Console.WriteLine("File Not Found");
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static double CalculateTax(double salary)
        {
            return (salary * (TAX_PERCENTAGE / 100));
        }
    }
}
