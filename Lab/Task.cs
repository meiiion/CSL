using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab
{
    static class Task
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
        /// Calculate: (Y % X) / sqrt(Z)
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
            try
            {
                Console.Clear();
                CultureInfo cultureInfo = new CultureInfo("ru_RU");
                
                Console.Write("First date span: ");
                DateSpan dateSpan1 = new DateSpan(Console.ReadLine());
                if (dateSpan1.From < dateSpan1.To) 
                    throw new DateSpanException("The beginning of the range must be greater than the end");
                
                Console.Write("Second date span: ");
                DateSpan dateSpan2 = new DateSpan(Console.ReadLine());
                if (dateSpan2.From < dateSpan2.To)
                    throw new DateSpanException("The beginning of the range must be greater than the end");

                if (dateSpan1.From == dateSpan2.From && dateSpan1.To == dateSpan2.To)
                {
                    if ((dateSpan1.From - dateSpan1.To).Days > 20) throw new TooBigSpanException("The span must be less than or equal to 20");
                    Console.WriteLine(Factorial((dateSpan1.To - dateSpan1.From).Days));
                }
                else
                if (dateSpan1.From > dateSpan2.From && dateSpan1.To < dateSpan2.To)
                {

                }
                else
                if (dateSpan1.From > dateSpan2.From && dateSpan1.To < dateSpan2.To)
                {

                }
                else
                if (dateSpan1.From < dateSpan2.From && dateSpan1.To > dateSpan2.To)
                {

                }
                else
                if (dateSpan1.From > dateSpan2.From && dateSpan1.To > dateSpan2.To)
                {

                }
                else
                if (dateSpan1.From < dateSpan2.From && dateSpan1.To < dateSpan2.To)
                {

                }
            }
            catch (System.FormatException)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid data format");
                Console.ResetColor();
            }
            catch (DateSpanException msg)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid date span: {msg.Message}");
                Console.ResetColor();
            }
            finally
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            }
        }
        
        
        
        
        
        
        //---------------------------------------------------------//
        private static long Factorial(int number) => number == 0 ? 1 : number * Factorial(number - 1);
        class DateSpan
        {
            public DateSpan(string dateSpan)
            {
                CultureInfo cultureInfo = new CultureInfo("ru_RU");
                Match match = Regex.Match(dateSpan, @"(\d{2}.\d{2}.\d{4}) - (\d{2}.\d{2}.\d{4})");
                From = DateTime.Parse(match.Groups[1].Value, cultureInfo);
                To = DateTime.Parse(match.Groups[2].Value, cultureInfo);
            }
            public DateTime From 
            {
                get;
            }
            public DateTime To
            {
                get;
            }

        }
    }
}
