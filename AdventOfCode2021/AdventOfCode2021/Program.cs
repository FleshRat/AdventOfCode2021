using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Christmas submarine control panel");
            Console.WriteLine("What would you like to do?");
            while (true)
            {
                MainMenu();
            }

        }
        public static bool MainMenu()
        {
            string infile;
            Console.WriteLine("Available Commands:");
            Console.WriteLine(" Move      DepthCheck     \n PowerConsumption  Exit");
            string input = Console.ReadLine();
            switch (input)
            {

                case "Move":
                    Console.WriteLine("Give me command file plz");
                    infile = Console.ReadLine();
                    Move(infile);
                    return true;
                    break;
                case "DepthCheck":
                    Console.WriteLine("Give me depth file plz");
                    infile = Console.ReadLine();
                    CalcDepths(infile);
                    return true;
                    break;
                case "Exit":
                    return false;
                    break;
                default:
                    Console.WriteLine("IDK What that is...");
                    return true;
                    break;
            }
        }

        public static void CalcDepths(string input)
        {
            double[] depths = File.ReadAllLines(input)
                .Select(s => double.Parse(s))
                .ToArray();
            // i = current j is previous k is last
            int depthChange = 0;
            int j = 1;
            int k = 0;
            double sum = depths[2] + depths[1] + depths[0]; // get first sum
            for (int i = 2; i < depths.Length; i++)
            {
                j = i - 1;
                k = i - 2;
                //if(depths[i] != depths[j]) { depthChange++; }

                if (sum < (depths[i] + depths[j] + depths[k])) { Console.WriteLine("Increased"); depthChange++; }
                else if (sum > (depths[i] + depths[j] + depths[k])) { Console.WriteLine("Decreased"); }
                else if (sum == (depths[i] + depths[j] + depths[k])) { Console.WriteLine("No Change"); }
                sum = (depths[i] + depths[j] + depths[k]);
            }

            Console.WriteLine("Total amount of depth increases: " + depthChange);
        }

        public static void Move(string input)
        {
            string[] commands = File.ReadAllLines(input);
            double position = 0;
            double depth = 0;
            double aim = 0;
            for(int i = 0; i < commands.Length; i++)
            {
                string[] command = commands[i].Split(' ');
                string direction = command[0];
                double distance = Convert.ToDouble(command[1]);
                switch (direction)
                {
                    case "forward":
                        position = position + distance;
                        depth = depth + (aim * distance);
                        break;
                    case "up":
                        aim = aim - distance;
                        break;
                    case "down":
                        aim = aim + distance;
                        break;
                }
                Console.WriteLine("Current Depth: " + depth + " Current horizontal position: " + position);
            }
            Console.WriteLine("Final horizontal position times final depth: " + depth * position);
        }

        public static void PowerConsumption(string input)
        {
            
        }
    }
}
