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
    class TaskStrings : Task
    {
        private class Strings
        {
            public string First { get; set; }
            public string Second{ get; set; }
            public Strings(string first, string second)
            {
                First = first;
                Second = second;
            }
            public static Strings Read()
            {
                Console.Write("First string: ");
                string str1 = Console.ReadLine();
                Console.Write("Second string: ");
                string str2 = Console.ReadLine();

                return new Strings(str1, str2);
            }
        }

        bool IsReversed(Strings strings)
        {
            bool reversed = false;
            for (int i = 0; i < (strings.First.Length > strings.Second.Length ? strings.Second.Length : strings.First.Length); i++)
                if (strings.First[(strings.First.Length > strings.Second.Length ? strings.First.Length : strings.First.Length) - i - 1] == strings.Second[i]) reversed = true;
                else
                {
                    reversed = false;
                    break;
                }
            return reversed;
        }

        class Props
        {
            public string Email { get; }
            public string IP { get; }
            public string Phone { get; }

            public Props(string s)
            {
                Match email = Regex.Match(s, @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}"),
                      ip    = Regex.Match(s, @"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+"),
                      phone = Regex.Match(s, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
                Email = email.Success ? email.Value : "не найден";
                IP    = ip.Success ? ip.Value : "не найден";
                Phone = phone.Success ? phone.Value : "не найден";
            }
        }

        public override void Execute()
        {
            Console.Clear();

            Strings strings = Strings.Read();
            
            //first
            
            Boolean match = false;
            for (int i = 0; i < (strings.First.Length>strings.Second.Length?strings.Second.Length:strings.First.Length); i++)
                if (strings.First[i] == strings.Second[i]) match = true; else
                {
                    match = false;
                    break;
                }
            Console.WriteLine(match ? "\nСтроки совпадают" : "\nСтроки не совпадают");

            //second

            Console.Write(
                $"\nFirst string: {Regex.Replace(strings.First.ToLower().Trim(' '), "[ ]+", " ")}" +
                $"\nSecond string: {Regex.Replace(strings.Second.ToLower().Trim(' '), "[ ]+", " ")}\n"
            );

            //third

            Console.WriteLine(
                IsReversed(strings) ? "\nПервая строка является перевертышем второй" 
                                    : "\nПервая строка не является перевертышем второй"
            );

            //fourth

            Props propsFirst  = new Props(strings.First),
                  propsSecond = new Props(strings.Second);

            Console.WriteLine(
                $"\nFirst string:\n" +
                $" - ip:\t\t{propsFirst.IP}\n" +
                $" - email:\t{propsFirst.Email}\n" +
                $" - phone:\t{propsFirst.Phone}\n" + 
                $"\nSecond string:\n" +
                $" - ip:\t\t{propsSecond.IP}\n" +
                $" - email:\t{propsSecond.Email}\n" +
                $" - phone:\t{propsSecond.Phone}\n");


            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
        }
    }
}
