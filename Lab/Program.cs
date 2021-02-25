﻿using System;
using ConsoleUI;

namespace Lab
{
    class Program
    { 
        /// <summary>
        /// pseudographic interface
        /// </summary>
        static void GraphicalMenuMode()
        {
            GraphicalMenu menu = new GraphicalMenu();
            menu.Add("       Hello World!       ", Task.HelloWorld);
            menu.Add("Calculate: (Y % X)/sqrt(Z)", Task.CalculateFormula);
            menu.Add("           Exit           ", () => { menu.Close(); });
            menu.MainLoop();
        }
        /// <summary>
        /// text interface
        /// </summary>
        static void NumericMenuMode()
        {
            NumericMenu menu = new NumericMenu();
            menu.Add("Hello World!", Task.HelloWorld);
            menu.Add("Calculate: (Y % X)/sqrt(Z)", Task.CalculateFormula);
            menu.Add("Recursion date", Task.RecursionDate);
            menu.Add("Exit", () => { menu.Close(); });
            menu.MainLoop();
        }
        static void ParseArguments(string[] args)
        {
            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-mi":

                        break;
                    case "-x	":
                        
                        break;
                    case "-y	":
                        
                        break;
                    case "-z	":
                        
                        break;
                    case "-d1st":
                        
                        break;
                    case "-d1end":
                        
                        break;
                    case "-d2st":
                        
                        break;
                    case "-d2end":
                        
                        break;
                    case "-s1":
                        
                        break;
                    case "-s2":
                        
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            //ParseArguments(args);
            if (args.Length == 1)
                if (args[0] == "-s")
                {
                    NumericMenuMode();
                    return;
                }
                else
                if (args[0] == "-i")
                {
                    GraphicalMenuMode();
                    return;
                }
            GraphicalMenu menu = new GraphicalMenu();
            menu.Add(" use graphical menu mode ", GraphicalMenuMode);
            menu.Add("  use numeric menu mode  ", NumericMenuMode);
            menu.Add("          Exit           ", () => { menu.Close(); });
            menu.MainLoop();
        }

    }
}