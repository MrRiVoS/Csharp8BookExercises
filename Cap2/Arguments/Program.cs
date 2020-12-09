using System;
using static System.Console;

namespace Arguments
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                WriteLine($"There are {args.Length} arguments.");
                WriteLine("You must specify two colors and dimensions, e.g.:");
                WriteLine("dotnet run red yellow 80 40");
                return;
            }

            WriteLine();
            foreach (string arg in args)
            {
                WriteLine(arg);
            }
            WriteLine();

            // Setting colors
            ForegroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[0],
                ignoreCase: true
            );
            BackgroundColor = (ConsoleColor)Enum.Parse(
                enumType: typeof(ConsoleColor),
                value: args[1],
                ignoreCase: true
            );

            // Setting dimensions
            try
            {
                WindowWidth = int.Parse(args[2]);
                WindowHeight = int.Parse(args[3]);
            }
            catch (PlatformNotSupportedException)
            {
                WriteLine("The current plataform does not support changing the size of a console window.");
            }
            
        }
    }
}
