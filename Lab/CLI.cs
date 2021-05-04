using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class CLI
    {
        private static void Usage()
        {

        }

        public static void ParseArguments(string[] args)
        {
            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "--help") Usage();
                    break;
                }
                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "--graphical":

                            break;
                        case "--numeric":

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid arguments");
                Console.ResetColor();
            }
        }
    }
}
