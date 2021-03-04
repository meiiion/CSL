using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab
{
    abstract class Task
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
            }
        }
        public Task(string title = "new task")
        {
        }
        public virtual void Execute()
        {

        }
    }

    class TaskHelloWorld : Task
    {
        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Hello World!");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }
    }
    class TaskCalculateFormula : Task
    {
        public override void Execute()
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
    }
    class TaskRecursionDate : Task
    {
        const int NMax = 20;
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
        private int GetN(DateSpan dateSpan1, DateSpan dateSpan2)
        {
            int n = 0;
            if (dateSpan1.From <= dateSpan2.From && dateSpan2.From <= dateSpan1.To && dateSpan1.To <= dateSpan2.To)
            {
                n = Convert.ToInt32((dateSpan1.To - dateSpan2.From).TotalDays) + 1;
            }
            else if (dateSpan2.From <= dateSpan1.From && dateSpan1.From <= dateSpan2.To && dateSpan2.To <= dateSpan1.To)
            {
                n = Convert.ToInt32((dateSpan2.To - dateSpan1.From).TotalDays) + 1;
            }
            else if (dateSpan1.From <= dateSpan2.From && dateSpan2.From <= dateSpan2.To && dateSpan2.To <= dateSpan1.To)
            {
                n = Convert.ToInt32((dateSpan2.To - dateSpan2.From).TotalDays) + 1;
            }
            else if (dateSpan2.From <= dateSpan1.From && dateSpan1.From <= dateSpan1.To && dateSpan1.To <= dateSpan2.To)
            {
                n = Convert.ToInt32((dateSpan1.To - dateSpan1.From).TotalDays) + 1;
            }
            return n;
        }
        public override void Execute()
        {
            try
            {
                Console.Clear();
                CultureInfo cultureInfo = new CultureInfo("ru_RU");

                Console.Write("First date span: ");
                DateSpan dateSpan1 = new DateSpan(Console.ReadLine());
                if (dateSpan1.From < dateSpan1.To)
                    throw new DateSpanException("The beginning of the span must be greater than the end");

                Console.Write("Second date span: ");
                DateSpan dateSpan2 = new DateSpan(Console.ReadLine());
                if (dateSpan2.From < dateSpan2.To)
                    throw new DateSpanException("The beginning of the span must be greater than the end");

                int N = GetN(dateSpan1, dateSpan2);
                if (N > NMax) throw new TooBigNException(N.ToString());
                Console.WriteLine(Factorial(N));
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
            catch (TooBigNException msg)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Too big N: {msg.Message}");
                Console.ResetColor();
            }
            finally
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            }
        }
    }
}
