using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab
{
    class Task
    {
        /// <summary>
        /// Print 'hello world'
        /// </summary>
        public static void HelloWorld()
        {
            Console.Clear();
            Console.WriteLine("Hello World!");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }
        /// <summary>
        /// Calculate: (Y % X)/sqrt(Z)
        /// </summary>
        public static void CalculateFormula()
        {
            try
            {
                Console.Clear();
                Console.Write("X = ");
                double X = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y = ");
                double Y = Convert.ToInt32(Console.ReadLine());
                Console.Write("Z = ");
                double Z = Convert.ToInt32(Console.ReadLine());

                if (Y == 0 && Z == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Y and Z cannot be zero");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("(Y % X)/sqrt(Z) = " + (Y % X / Math.Sqrt(Z)) + "\n");
                }
            }
            catch (System.FormatException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid data format");
                Console.ResetColor();
            }
            finally
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            }
        }

        public static void RecursionDate()
        {
            Console.Clear();

            Console.Write("First date span: ");
            Match match1 = Regex.Match(Console.ReadLine(), @"(\d{2}).(\d{2}).(\d{4}) - (\d{2}).(\d{2}).(\d{4})");
            
            Console.Write("Second date span: ");
            Match match2 = Regex.Match(Console.ReadLine(), @"(\d{2}).(\d{2}).(\d{4}) - (\d{2}).(\d{2}).(\d{4})");
            
            DateTime StartDate1 = new DateTime(Convert.ToInt32(match1.Groups[3].Value), Convert.ToInt32(match1.Groups[2].Value), Convert.ToInt32(match1.Groups[1].Value)),
                     EndDate1   = new DateTime(Convert.ToInt32(match1.Groups[6].Value), Convert.ToInt32(match1.Groups[5].Value), Convert.ToInt32(match1.Groups[4].Value)),
                     StartDate2 = new DateTime(Convert.ToInt32(match2.Groups[3].Value), Convert.ToInt32(match1.Groups[2].Value), Convert.ToInt32(match1.Groups[1].Value)),
                     EndDate2   = new DateTime(Convert.ToInt32(match2.Groups[6].Value), Convert.ToInt32(match1.Groups[5].Value), Convert.ToInt32(match1.Groups[4].Value));

            if (StartDate1 < EndDate1 || StartDate2 < EndDate2)
                throw new Exception();

            if (StartDate1 == StartDate2 && EndDate1 == EndDate2)
            {

            }
            else
            if (StartDate1 > StartDate2 && EndDate1 < EndDate2)
            {

            }
            else
            if (StartDate1 > StartDate2 && EndDate1 < EndDate2)
            {

            }
            else
            if (StartDate1 < StartDate2 && EndDate1 > EndDate2)
            {

            }
            else
            if (StartDate1 > StartDate2 && EndDate1 > EndDate2)
            {

            }
            else
            if (StartDate1 < StartDate2 && EndDate1 < EndDate2)
            {

            }
        }
        private static long Factorial(int number) => number == 0 ? 1 : number * Factorial(number - 1);
    }
}
